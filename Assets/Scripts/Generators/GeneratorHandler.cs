using System;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorHandler : MonoBehaviour
{
    public List<GeneratorInstance> generators;
    public int count;
    public GameObject OwnedGeneratorPrefab;
    public Transform GeneratorsPanel;
    private List<GameObject> genInstances = new List<GameObject>();
    
    public ScoreManager ScoreManager;

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
                count = generator.count;
                genInstances.Add(newGen);
            }
        }
    }

    public void LevelUp(int index)
    {
        var generator = generators[index];
        int cost = Mathf.RoundToInt(generator.GetNextLevelCost());

        if (ScoreManager.Instance.TrySpend(cost))
        {
            generator.level++;
            /*generator.GetNextSpeed();*/
        }
    }

    public void ManagerLevel(int index)
    {
        var generator = generators[index];
        generator.managerLevel++;
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

    public void SellPower(int index)
    {
        GeneratorInstance generator = generators[index];
        ScoreManager.AddScore(Mathf.RoundToInt(generator.GetPower()));
        generator.totalPower -= generator.GetPower();
    }

    /*public void ConvertPower()
    {
        ScoreManager.AddScore(Mathf.RoundToInt(totalPower)); 
        totalPower -= totalPower;
    }*/
    
    void TimeTickSystem_OnTick(object sender, TimeTickSystem.OnTickEventArgs e)
    {
        foreach (var gen in generators)
        {
            float production = gen.GetProductionPerSecond();
            gen.AddPower(production / 100);
        }
    }


    public void NewGameList()
    {
        foreach (var gen in generators)
        {
            gen.count = 0;
        }
        foreach (var gen in genInstances)
        {
            Destroy(gen.gameObject);
        }
    }
}
