using UnityEngine;

[System.Serializable]
public class GeneratorInstance
{
    public GeneratorData data;
    public int count;
    public float totalPower;
    public float totalPowerHist { get; private set; }
    public int level;
    public string name;
    
    public bool hasManager = false;



    public float GetProductionPerSecond()
    {
        return count * (data.baseProductionPerSecond * GetNextSpeed());
    }

    public string GetName()
    {
        return name = data.generatorName;
    }

    public int GetLevel()
    {
        return level = data.level;
    }

    /*public int GetManagerLevel()
    {
        return managerLevel = data.managerLevel;
    }*/

    public float GetPowerCap()
    {
       return data.basePowerCap * Mathf.Pow(1.15f, count);;
    }

    public float GetNextCost()
    {
        return data.baseCost * Mathf.Pow(1.25f, count);
    }
    
    public float GetManagerCost()
    {
        return data.baseCost * 100f;
    }
    
    public float GetNextLevelCost()
    {
        return data.baseCost * Mathf.Pow(1.5f, level);
    }

    public float GetNextSpeed()
    {
        return data.baseProductionPerSecond * Mathf.Pow(1.15f, level);
    }

    public void AddPower(float amount)
    {
        if (totalPower + amount > GetPowerCap())
        {
            totalPower = GetPowerCap();
        }
        else
        {
            totalPower += amount;
            totalPowerHist += amount;
        }
    }

    public float GetPower()
    {
        return totalPower;
    }


}
