using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("References")]
    public GameObject enemyPanel;
    public TMP_Text nameText;
    public TMP_Text gradeText;
    public TMP_Text speedText;
    public TMP_Text healthText;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClosePanel();
    }

    public void UpdatePanel(EnemyData enemyData, int currentHp)
    {
        nameText.text = $"Name : {enemyData.name}";
        gradeText.text = $"Grade : {enemyData.grade}";
        speedText.text = $"Speed : {enemyData.speed}";
        healthText.text = $"Health : {currentHp} / {enemyData.hp}";
    }

    public void OpenPanel(EnemyData enemyData, int currentHp)
    {
        UpdatePanel(enemyData, currentHp);

        enemyPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        enemyPanel.SetActive(false);
    }
}
