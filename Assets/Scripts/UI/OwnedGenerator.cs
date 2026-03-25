using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OwnedGenerator : MonoBehaviour
{
    [Header("Generator Config")]
    public int generatorIndex;
    public GeneratorInstance generator;
    private GeneratorHandler generatorHandler;
    private TextMeshProUGUI sellButtonText;
    public Image buttonImage;
    public TextMeshProUGUI countText;
    public GameObject sellButton;

    [Tooltip("Slider Bar")]
    public Slider bar;
    private float slideValue;

    [Tooltip("Sell whenever or only when slider is full")]
    public bool sellAnytime;

    private void Awake()
    {
        generatorHandler = FindAnyObjectByType<GeneratorHandler>();
        sellButtonText = sellButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Start()
    {
        generator = generatorHandler.generators[generatorIndex];
        buttonImage.sprite = generator.data.sprite;
        countText.text = generator.count.ToString() + "x"; 
        sellButtonText.text = "Sell Power\n" + generator.totalPower.ToString("N0") + "/" + generator.GetPowerCap().ToString("N0");

        bar.maxValue = generator.totalPower + generator.GetPowerCap();
        bar.value = generator.totalPower;
    }

    void Update()
    {
        countText.text = generator.count.ToString() + "x";
        sellButtonText.text = "Sell Power\n" + generator.totalPower.ToString("N0") + "/" + generator.GetPowerCap().ToString("N0");
        UpdateBar();
    }

    public void SellButton()
    {
        if (sellAnytime == false)//check if option enabled in inspector
        {
            if (bar.value == generator.GetPowerCap())
            {
                generatorHandler.SellPower(generatorIndex);
            }
            return;
        }
        else
        {
            generatorHandler.SellPower(generatorIndex);
        }
        
    }

    void UpdateBar()
    {
        if (bar != null)
        {
            bar.maxValue = generator.GetPowerCap();
            bar.value = generator.totalPower;
        }
    }

}
