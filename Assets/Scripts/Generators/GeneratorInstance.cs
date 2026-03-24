using UnityEngine;

[System.Serializable]
public class GeneratorInstance
{
    public GeneratorData data;
    public int count;
    public float totalPower;

    public float GetProductionPerSecond()
    {
        return count * data.baseProductionPerSecond;
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
