using UnityEngine;

[System.Serializable]
public class GeneratorInstance
{
    public GeneratorData data;
    public int count;
    public float totalPower;
    public int level;
    public string name;

    public float GetProductionPerSecond()
    {
        return count * data.baseProductionPerSecond;
    }

    public string GetName()
    {
        return name = data.generatorName;
    }

    public int GetLevel()
    {
        return level = data.level;
    }

    public float GetPowerCap()
    {
       return data.basePowerCap * count;
    }

    public float GetNextCost()
    {
        // exponential scaling (very common in clicker games)
        return data.baseCost * Mathf.Pow(1.15f, count);
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
        }
    }
    
    public float GetPower()
    {
        return totalPower;
    }


}
