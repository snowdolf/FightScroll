using UnityEngine;

public class Player : MonoBehaviour
{
    public LayerMask enemyLayer;

    private float radius = 12f;
    private int damage = 100;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
            if (IsEnemyFront(detectedEnemy.transform))
            {
                Enemy enemy = detectedEnemy.GetComponent<Enemy>();

                if (enemy != null)
                {
                    PlayArrowAnimation();
                }
            }
        }
    }

    bool IsEnemyFront(Transform enemyTransform)
    {
        return enemyTransform.position.x - transform.position.x > 1f;
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
