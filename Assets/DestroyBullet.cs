using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
        if (!collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
        }
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        //if we were able to get an enemy health
        if (enemy != null) {
            enemy.TakeDamage(damage);
        }
    }
}