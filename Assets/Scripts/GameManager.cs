using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemyIndex = 0;

    private GameObject enemyPrefab;
    private GameObject arrowPrefab;
    private List<EnemyData> enemyDataList;

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
        enemyPrefab = Resources.Load<GameObject>("Prefabs/enemy");
        arrowPrefab = Resources.Load<GameObject>("Prefabs/arrow");
        enemyDataList = CSVManager.LoadEnemyData("SampleMonster");
        SpawnEnemy();
    }

    public void SpawnEnemy(float delay = 0f)
    {
        StartCoroutine(SpawnEnemyAfterDelay(delay));
    }

    private IEnumerator SpawnEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        EnemyData enemyData;
        if (enemyIndex >= enemyDataList.Count)
        {
            enemyData = enemyDataList[Random.Range(0, enemyDataList.Count)];
        }
        else
        {
            enemyData = enemyDataList[enemyIndex];
        }

        GameObject enemyInstance = Instantiate(enemyPrefab);
        Enemy enemy = enemyInstance.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.enemyData = enemyData;
        }
    }

    public void SpawnArrow(int damage)
    {
        GameObject arrowInstance = Instantiate(arrowPrefab);
        Arrow arrow = arrowInstance.GetComponent<Arrow>();

        if (arrow != null)
        {
            arrow.damage = damage;
        }
    }
}
