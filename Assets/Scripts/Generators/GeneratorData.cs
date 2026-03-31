using UnityEngine;

[CreateAssetMenu(menuName = "Generator")]
public class GeneratorData : ScriptableObject
{
    public string generatorName;
    public float baseProductionPerSecond;
    public float baseCost;
    public float basePowerCap;
    public Sprite sprite;
    public int level;
    public int managerLevel;
}
