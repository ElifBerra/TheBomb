using UnityEngine;
using TMPro; // TextMeshPro kütüphanesi

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI scoreText; // Puan yazýsýný buraya sürükle
    public TextMeshProUGUI bombText;  // YENÝ: Bomba yazýsýný buraya sürükle

    [Header("Game Settings")]
    private int currentScore = 0;
    private int caughtBombs = 0;      // Yakalanan bomba sayýsý
    public  int MAX_BOMBS = 3;  // Oyunun biteceði sýnýr

    // Script açýldýðýnda olaylarý dinlemeye baþla
    private void OnEnable()
    {
        GameEvents.OnScoreItemCaught += UpdateScore; // Puan olayýna abone ol
        GameEvents.OnBombCaught += UpdateBombCount;  // Bomba olayýna abone ol
    }

    // Script kapandýðýnda dinlemeyi býrak (Hafýza sýzýntýsýný önler)
    private void OnDisable()
    {
        GameEvents.OnScoreItemCaught -= UpdateScore;
        GameEvents.OnBombCaught -= UpdateBombCount;
    }

    void Start()
    {
        // Oyun baþladýðýnda yazýlarý sýfýrla
        UpdateUI();
    }

    // Puan geldiðinde çalýþýr
    void UpdateScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateUI(); // Sadece UI'ý güncelle, baþka bir þey yapma
    }

    // Bomba yakalandýðýnda çalýþýr
    void UpdateBombCount()
    {
        caughtBombs++; // Sayacý 1 arttýr
        UpdateUI();    // UI'ý güncelle

        // 3. bombayý yakaladýk mý kontrol et
        if (caughtBombs >= MAX_BOMBS)
        {
            GameOver();
        }
    }

    // Ekrandaki yazýlarý güncelleyen yardýmcý fonksiyon
    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore;
        bombText.text = $"Bombs: {caughtBombs} / {MAX_BOMBS}";
    }

    // Oyun bittiðinde yapýlacaklar
    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0; // Oyunu dondur

        // Game Over mesajýný göster
        bombText.text = "GAME OVER!";
        bombText.color = Color.red; // Yazýyý kýrmýzý yap
        bombText.fontSize = 50; // Yazýyý büyüt (isteðe baðlý)
    }
}