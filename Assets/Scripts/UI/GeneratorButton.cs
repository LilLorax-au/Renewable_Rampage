using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorButton : MonoBehaviour
{
    private GeneratorInstance generator;
    public int generatorIndex;
    private GeneratorHandler generatorHandler;


    public Button buyGenerator;
    public Button buyManager;
    public Button buyUpgrade;


    public TextMeshProUGUI costText;
    public TextMeshProUGUI costManagerText;
    public TextMeshProUGUI costUpgradeText;

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


        buyGenerator.onClick.AddListener(OnBuyGeneratorPressed);
        buyManager.onClick.AddListener(OnBuyManagerPressed);
        buyUpgrade.onClick.AddListener(OnBuyLevelPressed);
    }

    void Update()
    {
        
    }

    public void OnBuyGeneratorPressed()
    {
        generatorHandler.BuyGenerator(generatorIndex);
        costText.text = "$" + generator.GetNextCost().ToString("N0");
        //DEBUG
        //generatorHandler.LevelUp(generatorIndex);

    }

    public void OnBuyManagerPressed()
    {
        generatorHandler.ManagerLevel(generatorIndex);
        //costManagerText.text = "$" + generator.GetNextCost().ToString("N0");
    }


    public void OnBuyLevelPressed()
    {
        generatorHandler.LevelUp(generatorIndex);
        //costUpgradeText.text = "$" + generator.GetNextCost().ToString("N0");
        //generator.LevelUp();
    }


}
