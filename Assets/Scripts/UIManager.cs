using UnityEngine;
using TMPro; 

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI bombText; 

    [Header("Game Settings")]
    private int currentScore = 0;
    private int caughtBombs = 0;   
    public  int MAX_BOMBS = 3;

    private void OnEnable()
    {
        GameEvents.OnScoreItemCaught += UpdateScore; 
        GameEvents.OnBombCaught += UpdateBombCount;  
    }

    private void OnDisable()
    {
        GameEvents.OnScoreItemCaught -= UpdateScore;
        GameEvents.OnBombCaught -= UpdateBombCount;
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateUI(); 
    }

    void UpdateBombCount()
    {
        caughtBombs++; 
        UpdateUI(); 

        if (caughtBombs >= MAX_BOMBS)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore;
        bombText.text = $"Bombs: {caughtBombs} / {MAX_BOMBS}";
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;

        bombText.text = "GAME OVER!";
        bombText.color = Color.red;
        bombText.fontSize = 50; 
    }
}