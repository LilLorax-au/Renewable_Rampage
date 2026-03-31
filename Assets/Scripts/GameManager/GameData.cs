using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gameLevel;
    public int power;
    public int money;
    //public List<string> generators;
    

    public GameData(GameManager data)//GameManager is the GameManager.cs script, GameManager data script
    {
        gameLevel = data.gameLevel;
        power = data.power;
        money = data.money;
        //generators = data.generators;
        
    }
}

