using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemyIndex = 0;

    private GameObject enemyPrefab;
    private GameObject arrowPrefab;
    private List<Dictionary<string, object>> enemyDataList;

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
        enemyDataList = CSVReader.Read("SampleMonster");
        SpawnEnemy();
    }

    public void SpawnEnemy(float delay = 0f)
    {
        StartCoroutine(SpawnEnemyAfterDelay(delay));
    }

    private IEnumerator SpawnEnemyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (enemyIndex >= enemyDataList.Count)
        {
            enemyIndex = Random.Range(0, enemyDataList.Count);
        }
        EnemyData enemyData = new()
        {
            name = enemyDataList[enemyIndex]["Name"].ToString(),
            grade = enemyDataList[enemyIndex]["Grade"].ToString(),
            speed = float.Parse(enemyDataList[enemyIndex]["Speed"].ToString()),
            hp = int.Parse(enemyDataList[enemyIndex]["Health"].ToString()),
            animatorFileName = enemyDataList[enemyIndex]["Animator"].ToString()
        };

        GameObject enemyInstance = Instantiate(enemyPrefab);
        Enemy enemy = enemyInstance.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.enemyData = enemyData;
            enemy.UpdateAnimation();
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
