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

    // Update is called once per frame
    void Update()
    {
        if (indexPower > stats[0].Count - 1) { indexPower = 0; }
        if (indexMoney > stats[1].Count - 1) { indexMoney = 0; }
        if (indexLevel > stats[2].Count - 1) { indexLevel = 0; }
        Debug.Log(gm.money.ToString());
        // Testing before major chnage
        stats[0][indexPower].text = "Power: " + gm.moneyHist.ToString();
        stats[1][indexMoney].text = "Money: " + gm.moneyHist.ToString();
        stats[2][indexLevel].text = "Level: " + gm.gameLevelHist.ToString();


        indexPower++;
        indexMoney++;
        indexLevel++;


    }
}
