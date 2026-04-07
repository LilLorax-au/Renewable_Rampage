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

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI costManagerText;
    public TextMeshProUGUI costUpgradeText;

    public Image buttonImage;

    private void Awake()
    {
        generatorHandler = FindAnyObjectByType<GeneratorHandler>();
        buyManager.interactable = false;
        buyUpgrade.interactable = false;
    }

    void Start()
    {
        generator = generatorHandler.generators[generatorIndex];

        nameText.text = generator.name;
        costText.text = "$" + generator.GetNextCost().ToString("N0");
        costUpgradeText.text = "$" + generator.GetNextLevelCost().ToString("N0");
        costManagerText.text = "$" + generator.GetManagerCost().ToString("N0");
        buttonImage.sprite = generator.data.sprite;

        buyGenerator.onClick.AddListener(OnBuyGeneratorPressed);
        buyManager.onClick.AddListener(OnBuyManagerPressed);
        buyUpgrade.onClick.AddListener(OnBuyLevelPressed);
    }

    public void OnBuyGeneratorPressed()
    {
        generatorHandler.BuyGenerator(generatorIndex);
        costText.text = "$" + generator.GetNextCost().ToString("N0");
        
        if (generator.count > 0)
        { 
            buyManager.interactable = true;
            buyUpgrade.interactable = true;
        }
        //DEBUG
        //generatorHandler.LevelUp(generatorIndex);

    }

    public void OnBuyManagerPressed()
    {
        generatorHandler.AddManager(generatorIndex);
        //costManagerText.text = "$" + generator.GetManagerCost().ToString("N0");
    }


    public void OnBuyLevelPressed()
    {
        generatorHandler.LevelUp(generatorIndex);
        costUpgradeText.text = "$" + generator.GetNextLevelCost().ToString("N0");
        //generator.LevelUp();
    }

    public void UpdateButtons(long score)
    {
        
    }


}
