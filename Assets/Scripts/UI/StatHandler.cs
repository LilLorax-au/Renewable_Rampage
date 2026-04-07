using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    private GameManager gm;
    private string[] tags = { "PowerStatTag", "MoneyStatTag", "LevelStatTag" };
    private List<List<TextMeshProUGUI>> stats = new List<List<TextMeshProUGUI>>();
    private int indexPower = 0;
    private int indexMoney = 0;
    private int indexLevel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (stats.Count > 0)
        {
            CheckIndex();
            UpdateStats();
            IncrementIndex();
        }
        else
        {
            FindStatTags();
        }

    }

    /// <summary>
    /// Updates stats to most current values
    /// </summary>
    void UpdateStats()
    {
        stats[0][indexPower].text = "Power: " + gm.moneyHist.ToString();
        stats[1][indexMoney].text = "Money: " + gm.moneyHist.ToString();
        stats[2][indexLevel].text = "Level: " + gm.gameLevelHist.ToString();
    }

    /// <summary>
    /// Check index is within range, if its not, sets value to 0
    /// </summary>
    void CheckIndex()
    {
        if (indexPower > stats[0].Count - 1) { indexPower = 0; }
        if (indexMoney > stats[1].Count - 1) { indexMoney = 0; }
        if (indexLevel > stats[2].Count - 1) { indexLevel = 0; }
    }

    /// <summary>
    /// mass index update, increments only once per call
    /// </summary>
    void IncrementIndex()
    {
        indexPower++;
        indexMoney++;
        indexLevel++;
    }

    /// <summary>
    /// Finds all instances of 'tags' array. NOTE: due to the nature of this at 02/04/2026, 
    /// if the scrip is called before taged object exist, the stats wont writen to them.
    /// </summary>
    void FindStatTags()
    {
        for (int i = 0; i < tags.Length; i++)
       {    
            stats.Add(new List<TextMeshProUGUI>());
            GameObject[] tempObj = GameObject.FindGameObjectsWithTag(tags[i]);
            
            for (int j = 0; j < tempObj.Length; j++)
            {
                stats[i].Add(tempObj[j].GetComponent<TextMeshProUGUI>());
                Debug.Log(stats[i][j].text);
            }
        }
    }
}
