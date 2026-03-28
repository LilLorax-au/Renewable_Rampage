using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorButton : MonoBehaviour
{
    private GeneratorInstance generator;
    public int generatorIndex;
    private GeneratorHandler generatorHandler;
    
    public TextMeshProUGUI costText;
    public Image buttonImage;

    private void Awake()
    {
        generatorHandler = FindAnyObjectByType<GeneratorHandler>();
    }

    void Start()
    {
        generator = generatorHandler.generators[generatorIndex];
        costText.text = "$" + generator.GetNextCost().ToString("N0");
        buttonImage.sprite = generator.data.sprite;
    }
    public void OnBuyPressed()
    {
        generatorHandler.BuyGenerator(generatorIndex);
        costText.text = "$" + generator.GetNextCost().ToString("N0");
        //DEBUG
        generatorHandler.LevelUp(generatorIndex);

    }



}
