using TMPro;
using UnityEngine;

public class DebugStats : MonoBehaviour
{
    private GeneratorHandler _generatorHandler;
    public TextMeshProUGUI tickText;
    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI frameTimeText;
    private TimeTickSystem timeTick;
    private float ticksPerSecond;
    private float frameTime;
    private float fps;
    
    private ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        timeTick = GameObject.Find("Time_Tick_System").GetComponent<TimeTickSystem>();
        _generatorHandler = GameObject.Find("Generator_Handler").GetComponent<GeneratorHandler>();

    }

    // Update is called once per frame
    void Update()
    {
        //STATS
        fps = Mathf.Round((1f / Time.unscaledDeltaTime) * 100.0f) * 0.01f;

        fpsText.text = fps.ToString(); 

        frameTime = Mathf.Round(Time.unscaledDeltaTime * 100.0f) * 0.01f;
        frameTimeText.text = frameTime.ToString() + "ms"; 

        //Tickrate
        ticksPerSecond = Mathf.Round(timeTick.tickRate * 100.0f) * 0.01f;

        tickText.text = ticksPerSecond.ToString() + "ms";
        /*text.text = "Power: " + _generatorHandler.GetPower().ToString("F");*/
    }

    /*Fix for debug menu, use these to change score with buttons*/
    public void DebugAddScore(int score)
    {
        long longValue = score;
        scoreManager.AddScore(longValue);
    }

    public void DebugRemoveScore(int score)
    {
        long longValue = score;
        scoreManager.RemoveScore(longValue);
    }
}
