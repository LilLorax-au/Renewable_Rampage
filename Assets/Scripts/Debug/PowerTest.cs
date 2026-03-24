using TMPro;
using UnityEngine;

public class PowerTest : MonoBehaviour
{
    private GeneratorHandler _generatorHandler;
    private TextMeshProUGUI text;
    private string POWER_UNIT = "Ah"; 
    public bool useUnit = true;
    public string placeHolderText = "Power:";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _generatorHandler = GameObject.Find("GeneratorHandler").GetComponent<GeneratorHandler>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = placeHolderText + " " + _generatorHandler.GetPower().ToString("F") + (useUnit? POWER_UNIT : "");
    }
}
