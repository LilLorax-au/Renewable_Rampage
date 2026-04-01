using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    private GameData gameData;
    private string[] tags = { "PowerStatTag", "MoneyStatTag", "LevelStatTag" };
    private List<List<TextMeshProUGUI>> stats = new List<List<TextMeshProUGUI>>();
    private int indexPower = 0;
    private int indexMoney = 0;
    private int indexLevel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int i = 0; i < tags.Length; i++)
       {    
            stats.Add(new List<TextMeshProUGUI>());
            GameObject[] tempObj = GameObject.FindGameObjectsWithTag(tags[i]);
            
            for (int j = 0; j < tempObj.Length; j++)
            {
                stats[i].Add(tempObj[j].GetComponent<TextMeshProUGUI>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (indexPower > stats[0].Count - 1) { indexPower = 0; }
        if (indexMoney > stats[1].Count - 1) { indexMoney = 0; }
        if (indexLevel > stats[2].Count - 1) { indexLevel = 0; }
        // Testing before major chnage
        stats[0][indexPower].text = "Power: ";
        stats[1][indexMoney].text = "Money: ";
        stats[2][indexLevel].text = "Level: ";

        indexPower++;
        indexMoney++;
        indexLevel++;


    }
}
