using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public GameObject enemyObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy(float delay = 0f)
    {
        StartCoroutine(SpawnEnemyAfterDelay(delay));
    }

    private IEnumerator SpawnEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(enemyObject);
    }
}
