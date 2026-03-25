using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int score = 50;
    
    // UI updates on event
    public event System.Action<int> OnScoreChanged;

    private void Awake()
    {
        // Persists between scenes
        DontDestroyOnLoad(gameObject);
        // Setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }
    
    public void RemoveScore(int amount)
    {
        score -= amount;
        OnScoreChanged?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }
    
    public bool TrySpend(int amount)
    {
        if (score >= amount)
        {
            score -= amount;
            OnScoreChanged?.Invoke(score);
            return true;
        }

        return false;
    }
}
