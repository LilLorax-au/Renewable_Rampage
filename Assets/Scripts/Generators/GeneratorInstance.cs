using UnityEngine;

[System.Serializable]
public class GeneratorInstance
{
    public GeneratorData data;
    public int count;

    public float GetProductionPerSecond()
    {
        return count * data.baseProductionPerSecond;
    }

    public float GetNextCost()
    {
        // exponential scaling (very common in clicker games)
        return data.baseCost * Mathf.Pow(1.15f, count);
    }
}
