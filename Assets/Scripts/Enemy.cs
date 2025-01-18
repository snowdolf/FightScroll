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
            DeadEnemy();
        }
    }

    private void OnMouseDown()
    {
        UIManager.Instance.OpenPanel(enemyData, currentHp);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GameManager.Instance.enemyIndex++;
            DeadEnemy();
        }
        else
        {
            frontHpBar.localScale = new Vector3((float)currentHp / enemyData.hp, 1f, 1f);
            UIManager.Instance.UpdatePanel(enemyData, currentHp);
        }
    }

    private void DeadEnemy()
    {
        GameManager.Instance.SpawnEnemy(5f);
        UIManager.Instance.ClosePanel();
        Destroy(gameObject);
    }
}

public class EnemyData
{
    public string name;
    public string grade;
    public float speed;
    public int hp;
}