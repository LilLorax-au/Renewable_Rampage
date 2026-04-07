using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public long score;
    public long scoreHist;
    
    // UI updates on event
    public event System.Action<long> OnScoreChanged;

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

    public void AddScore(long amount)
    {
        score += amount;
        scoreHist += amount;
        OnScoreChanged?.Invoke(score);
    }
    
    public void RemoveScore(long amount)
    {
        score -= amount;
        OnScoreChanged?.Invoke(score);
    }

    public long GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }
    
    public bool TrySpend(long amount)
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
