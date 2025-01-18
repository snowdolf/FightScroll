using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 1f;
    public int FullHp = 200;
    int currentHp;

    [Header("References")]
    public RectTransform frontHpBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = FullHp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            GameManager.Instance.SpawnEnemy(5f);
            Destroy(gameObject);
        }
        frontHpBar.localScale = new Vector3((float)currentHp / FullHp, 1f, 1f);
    }
}
