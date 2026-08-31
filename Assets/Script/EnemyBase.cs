using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    [Header("组件")]
    public Animator anim;
    public GameObject attackTrigger1;
    public Transform attackPos1;
    public Rigidbody2D rb;
    public Player player;
    public SpriteRenderer sr;
    [Header("Bool变量")]
    public bool playerInRange = false;
    public bool canAttack1 = true;
    [Header("基础属性")]
    public int ATK = 5;
    public int HP = 100;    
    private int HPNow = 100;
    [Header("血量相关变量")]
    public Slider hpBar;
    public GameObject deadVFX;
    [Header("怪物移动")]
    public Transform[] movePos;
    public float moveSpeed = 2.0f;
    private Transform tarPos;
    private bool waitIdle = false;

    void Start()
    {
        if(movePos.Length > 1){tarPos = movePos[Random.Range(0, movePos.Length)];}
        else{Debug.LogError("移动点数量不足");}
    }

    void Update()
    {
        CreatAttackTrigger1();
        if(!anim.GetBool("IsGetHit"))
        {
            Move();
        }
    }

    public void TakeDamage(int damage,Transform owner)
    {
        //动画与击退效果
        CancelInvoke(nameof(GetHitAnimEnd));
        anim.SetBool("IsGetHit", true);
        Vector2 dir = (transform.position - owner.position).normalized;
        rb.velocity = dir * 10.0f;
        Invoke(nameof(GetHitAnimEnd), 0.4f);
        //血量减少与血条显示
        CancelInvoke(nameof(HPBarHide));
        HPNow -= damage;
        hpBar.gameObject.SetActive(true);
        hpBar.value = (float)HPNow / (float)HP;
        Invoke(nameof(HPBarHide), 2.0f);
        //死亡判定
        //死亡判定
        if (HPNow <= 0)
        {
            Instantiate(deadVFX, transform.position, transform.rotation);
            Destroy(gameObject);
            //胜利判定：Destroy是帧末才真正销毁，所以此刻自己仍被算在内，
            //Length <= 1 表示这是最后一只存活的怪物
            if (FindObjectsOfType<EnemyBase>().Length <= 1)
            {
                //includeInactive=true：即使胜利面板初始为不激活也能找到并显示
                FindObjectOfType<WinUI>(true)?.ShowWinUI();
            }
        }
    }


    public void GetHitAnimEnd()
    {
        anim.SetBool("IsGetHit", false);
    }

    public void HPBarHide()
    {
        hpBar.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = true;
            player = collision.GetComponent<Player>();
        }
    }


    public void CreatAttackTrigger1()
    {
        if(playerInRange)
        {
            if(canAttack1)
            {
                CancelInvoke(nameof(Attack1End));
                 GameObject go = Instantiate(attackTrigger1, attackPos1.position,
                    attackPos1.rotation,attackPos1);
                go.GetComponent<EnemyAttackTrigger>().
                    SetDamage(ATK + Random.Range(0, 5),transform);
                canAttack1 = false;
                Invoke(nameof(Attack1End), 0.4f);
            }

            if(Vector2.Distance(transform.position,
                player.transform.position) > 3f)
            {
                playerInRange = false;
            }
        }
    }

    public void Attack1End()
    {
        canAttack1 = true;
    }

    public void Move()
    {
        if(waitIdle)
        { 
            rb.velocity = Vector2.zero ; 
            anim.SetBool("IsMove", false);
            return; 
        }

        Vector3 dir = (tarPos.position - transform.position).normalized;
        if(Vector3.Distance(transform.position, tarPos.position) > 0.5f)
        {
            rb.velocity = dir * moveSpeed;
            anim.SetBool("IsMove", true);
            sr.flipX = (rb.velocity.x < 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
            tarPos = GetNewTarPos();
            waitIdle = true;
            Invoke(nameof(RestWaitIdle), 1.0f);
        }
    }

    public void RestWaitIdle()
    {
        waitIdle = false;
    }

    public Transform GetNewTarPos()
    {
        if(movePos.Length < 2)
        { return transform; }

        Transform tar;
        tar = movePos[Random.Range(0, movePos.Length)];
        if(tar != tarPos){return tar;}
        else{return GetNewTarPos();}
    }

}
