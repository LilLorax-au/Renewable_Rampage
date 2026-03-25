using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OwnedGenerator : MonoBehaviour
{
    public int generatorIndex;
    private GeneratorInstance generator;
    private GeneratorHandler generatorHandler;
    public Image buttonImage;

    public TextMeshProUGUI countText;
    public GameObject sellButton;
    private TextMeshProUGUI sellButtonText;

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
    }

    void Update()
    {
        countText.text = generator.count.ToString() + "x";
        sellButtonText.text = "Sell Power\n" + generator.totalPower.ToString("N0") + "/" + generator.GetPowerCap().ToString("N0");
    }

    public void SellButton()
    {
        generatorHandler.SellPower(generatorIndex);
    }
}
