using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    int currentHp;

    [Header("References")]
    public RectTransform frontHpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = enemyData.hp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * enemyData.speed * Time.deltaTime;
        if (transform.position.x <= -10f)
        {
            GameManager.Instance.SpawnEnemy(5f);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GameManager.Instance.enemyIndex++;
            GameManager.Instance.SpawnEnemy(5f);
            Destroy(gameObject);
        }
        frontHpBar.localScale = new Vector3((float)currentHp / enemyData.hp, 1f, 1f);
    }
}

public class EnemyData
{
    public string name;
    public string grade;
    public float speed;
    public int hp;
}