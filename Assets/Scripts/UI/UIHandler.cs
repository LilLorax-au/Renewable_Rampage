
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateUI;
        scoreText.text = "$" + ScoreManager.Instance.GetScore().ToString("N0");
    }

    void UpdateUI(int newScore)
    {
        scoreText.text = ("$" + newScore.ToString("N0"));
    }
}
