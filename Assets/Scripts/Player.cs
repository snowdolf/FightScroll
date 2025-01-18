using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float radius = 10f;
    public LayerMask enemyLayer;
    public int damage = 100;

    [Header("References")]
    public Animator animator;

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
                PlayArrowAnimation();
            }
        }
    }

    void PlayArrowAnimation()
    {
        animator.SetTrigger("IsAttack");
    }

    public void ShootArrow()
    {
        GameManager.Instance.SpawnArrow(damage);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
