using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHandler : MonoBehaviour
{
    public List<GeneratorInstance> generators;
    
    public GameObject OwnedGeneratorPrefab;
    public Transform GeneratorsPanel;
    
    public ScoreManager ScoreManager;
    
    private float totalPower;

    private void Start()
    {
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }

    public void BuyGenerator(int index)
    {
        var generator = generators[index];

        int cost = Mathf.RoundToInt(generator.GetNextCost());

        if (ScoreManager.Instance.TrySpend(cost))
        {
            if (generator.count > 0)
            {
                generator.count++;
            }
            else
            {
                generator.count++;
                GameObject newGen = Instantiate(OwnedGeneratorPrefab, GeneratorsPanel);
                newGen.GetComponent<OwnedGenerator>().generatorIndex = index;
            }

            Debug.Log("Bought! New count: " + generator.count);
        }
    }

    public float GetTotalProductionPerSecond()
    {
        float total = 0f;

        foreach (var gen in generators)
        {
            total += gen.GetProductionPerSecond();
        }

        return total;
    }

    public void AddPower(float amount)
    {
        totalPower += amount;
    }

    public void ConvertPower()
    {
        ScoreManager.AddScore(Mathf.RoundToInt(totalPower)); 
        totalPower -= totalPower;
    }

    public float GetPower()
    {
        return totalPower;
    }
    
    void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        float production = GetTotalProductionPerSecond();
        AddPower(production / 100);
    }
}
