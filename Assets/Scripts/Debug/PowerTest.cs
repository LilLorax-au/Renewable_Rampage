using TMPro;
using UnityEngine;

public class PowerTest : MonoBehaviour
{
    private GeneratorHandler _generatorHandler;
    private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _generatorHandler = GameObject.Find("GeneratorHandler").GetComponent<GeneratorHandler>();
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /*text.text = "Power: " + _generatorHandler.GetPower().ToString("F");*/
    }
}
