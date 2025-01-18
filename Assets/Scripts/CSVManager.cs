using System.Collections.Generic;
using UnityEngine;

public class CSVManager : MonoBehaviour
{
    public static List<EnemyData> LoadEnemyData(string fileNmae)
    {
        List<EnemyData> enemyDataList = new List<EnemyData>();

        TextAsset csvFile = Resources.Load<TextAsset>(fileNmae);

        if (csvFile != null)
        {
            string[] lines = csvFile.text.Split("\n");
            bool isFirstLine = true;

            foreach (string line in lines)
            {
                if (isFirstLine)
                {
                    isFirstLine = false;
                    continue;
                }

                string[] fields = line.Split(",");

                EnemyData enemyData = new()
                {
                    name = fields[0],
                    grade = fields[1],
                    speed = float.Parse(fields[2]),
                    hp = int.Parse(fields[3])
                };

                enemyDataList.Add(enemyData);
            }
        }

        return enemyDataList;
    }
}