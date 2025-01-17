using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float radius = 13f;
    public LayerMask enemyLayer;
    public int damage = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("DetectEnemy", 1f, 1f);
    }

    void DetectEnemy()
    {
        Collider2D detectedEnemy = Physics2D.OverlapCircle(transform.position, radius, enemyLayer);

        if (detectedEnemy != null)
        {
            Enemy enemy = detectedEnemy.GetComponent<Enemy>();

            if (enemy != null)
            {
                AttackEnemy(enemy);
            }
        }
    }

    void AttackEnemy(Enemy enemy)
    {
        enemy.TakeDamage(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
