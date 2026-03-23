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

    private void Awake()
    {
        generatorHandler = FindAnyObjectByType<GeneratorHandler>();
    }

    void Start()
    {
        generator = generatorHandler.generators[generatorIndex];
        buttonImage.sprite = generator.data.sprite;
        countText.text = generator.count.ToString() + "x";
    }

    void Update()
    {
        countText.text = generator.count.ToString() + "x";
    }
}
