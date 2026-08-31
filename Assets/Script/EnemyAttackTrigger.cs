using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public int damage;
    public Transform owner;

    private void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage, owner);
        }
    }
    public void SetDamage(int Num, Transform Owner)
    {
        damage = Num;
        owner = Owner;
    }
}
