using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public int damage = 10;
    public Transform owner;

    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyBase>().
                TakeDamage(damage, owner);
        }
    }

    public void SetDamage(int Num, Transform Owner)
    {
        damage = Num;
        owner = Owner;
    }



}
