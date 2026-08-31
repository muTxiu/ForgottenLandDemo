using UnityEngine;
using UnityEngine.UI;

public enum WeaponType { Sword, Bow, Staff }

public class Player : MonoBehaviour
{
    [Header("基础属性")]
    public float speed = 5f;
    public int HP = 100;
    private int HPNow = 100;
    public int ATK = 10;    
    private float h, v;
    [Header("组件")]
    public Rigidbody2D rb;
    public Animator animPlayer;
    public Animator animSword;
    public Animator animSlash;
    public SpriteRenderer sr;
    public GameObject swordTri;
    public Transform swordTriPos;
    public Slider hpBar;
    [Header("玩家死亡")]
    public GameObject deadVFX;
    public bool isDead = false;
    public GameObject deadUI;
    [Header("攻击")]
    public GameObject[] weapons;
    public GameObject[] weaponsUI;
    public GameObject arrowTri;
    public Transform arrowTriPos;
    public AudioSource audioVFX;
    public AudioClip attackSound;
    public WeaponType currentWeapon = WeaponType.Sword;





    void Start()
    {
        HPNow = HP;
    }


    void Update()
    {
        if(!isDead)
        {
            Move();
            SwitchWeapon();
            Attack();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(h * speed, v * speed);
        if(h!=0 || v !=0)
        {
            animPlayer.SetBool("IsRun", true);
        }
        else
        {
            animPlayer.SetBool("IsRun", false);
        }

        if (h > 0) { sr.flipX = false; }
        else if( h < 0) { sr.flipX = true; }
    }

    public void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(currentWeapon == WeaponType.Sword)//剑
            {
                animSword.SetTrigger("Attack1");
                animSlash.SetTrigger("Attack1");
                GameObject go = Instantiate(swordTri, swordTriPos.position,
                    swordTriPos.rotation, swordTriPos);
                go.GetComponent<PlayerAttackTrigger>().
                    SetDamage(ATK + Random.Range(0, 5), transform);
                audioVFX.PlayOneShot(attackSound);
            }
            else if(currentWeapon == WeaponType.Bow)//弓
            {
                GameObject go = Instantiate(arrowTri, arrowTriPos.position,
                    arrowTriPos.rotation);
            }
            else if(currentWeapon == WeaponType.Staff)//杖
            {

            } 
        }
    }

    public void SwitchWeapon()
    {
      if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            HideWeapons();
            currentWeapon = WeaponType.Sword;
            weapons[0].SetActive(true);
            weaponsUI[0].SetActive(true);
        }
    }

    public void HideWeapons()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
            weaponsUI[i].SetActive(false);
        }
    }

    public void TakeDamage(int damage,Transform owner)
    {
        //扣血
        CancelInvoke(nameof(GetHitAnimEnd));
        animPlayer.SetBool("IsGetHit", true);
        HPNow = HPNow - damage;
        hpBar.value = (float)HPNow / (float)HP;
        Invoke(nameof(GetHitAnimEnd), 0.4f);
        //死亡
        if (HPNow <= 0)
        {
            Instantiate(deadVFX, transform.position, transform.rotation);
            gameObject.SetActive(false);
            isDead = true;
            deadUI.SetActive(true);
        }
    }

    public void GetHitAnimEnd()
    {
        animPlayer.SetBool("IsGetHit", false);
    }
}
