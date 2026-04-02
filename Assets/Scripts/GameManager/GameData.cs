using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gameLevel;
    public int gameLevelHist;
    public long power;
    public long powerHist;
    public long money;
    public long moneyHist;
    
    //public List<string> generators;
    

    public GameData(GameManager data)//GameManager is the GameManager.cs script, GameManager data script
    {
        gameLevel = data.gameLevel;
        gameLevelHist = data.gameLevelHist;
        power = data.power;
        powerHist = data.powerHist;
        money = data.money;
        moneyHist = data.moneyHist;
        //generators = data.generators;
        
    }
}

