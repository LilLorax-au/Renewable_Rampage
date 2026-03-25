using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Menus Configs")]
    [SerializeField] public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;
    public Button saveButton;
    //public Button loadButton;
    public Button mainMenu;
    public string menu;
    

    [Header("Slider Configs")]
    public Slider bar;
    public float barValue;
    public float barMaxValue;

    [Header("Level Configs")]
    public TextMeshProUGUI gameLevelText;
    public TextMeshProUGUI totalPowerOutputText;
    public float totalPowerOutput = 1f;

    //GAME DATA
    [Header("Session Data")]
    [SerializeField] public int gameLevel = 10;
    [SerializeField] public int power = 10;
    [SerializeField] public int money = 100;
    //public List<string> generators;
    [SerializeField] public int level;



    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ContinueGame);
        mainMenu.onClick.AddListener(MainMenu);
        saveButton.onClick.AddListener(SaveGame);
        //loadButton.onClick.AddListener(LoadGame);
        LoadGame();//FORCE LOAD, I HAVE YET TO SORT LOAD ON SCENE CHANGE, WILL ADRESS IN UPCOMING COMIT
        gameLevelText.text = "Lv:" + gameLevel;
        totalPowerOutputText.text = totalPowerOutput + "Kwh";
        bar.maxValue = barMaxValue;
        barValue = bar.value;
         
    }
    void Update()
    {
        totalPowerOutputText.text = Mathf.Round(totalPowerOutput * 100.0f) + "Kwh";
        UpdateLevel();
        totalPowerOutputText.text = totalPowerOutput + "Kwh";
        return;
    }
    private void PauseGame()
    {
        
        pauseMenu.SetActive(true);
        //Disable scripts that still work while timescale is set to 0

        StartCoroutine(Delay(0.01f)); // Safety Delay to ensure action is complete
        Time.timeScale = 0;
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        StartCoroutine(Delay(0.01f));
        pauseMenu.SetActive(false);
        //enable the scripts again

    }

    public void SaveGame()
    {
        SaveLoad.SaveData(this);
        Debug.Log($"Game Data is loaded.");

    }

    public void LoadGame()
    {
        if (SaveLoad.LoadData() == null) return;
        GameData data = SaveLoad.LoadData();
    
        gameLevel = data.gameLevel;
        power = data.power;
        money = data.money;
    
    }

    void MainMenu()
    {
        SceneManager.LoadScene(menu);
    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Safety delay for pause game
        
    }

    void UpdateLevel()
    {
        barValue = bar.value;
        if (barValue >= barMaxValue)
        {
            bar.value = 0;
            LevelUp();
        }
        else if (barValue != barMaxValue)
        {
            bar.value++;
            totalPowerOutput += 0.1f;
            totalPowerOutputText.text = Mathf.Round(totalPowerOutput * 10.0f) * gameLevel + "Kwh";
            StartCoroutine(Delay(1.0f));

            return;
        }
    }

    void LevelUp()
    {
        gameLevel = gameLevel + 1; ;
        gameLevelText.text = "Lv:" + gameLevel;
    }
    
}