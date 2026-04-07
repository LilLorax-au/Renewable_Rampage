using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    private GeneratorHandler generatorHandler;


    [Header("Scene Objects")]
    public GameObject menuObject;
    public GameObject levelObject;

    [Header("Scene Active Debug")]
    public bool activeMenu;
    public bool activeLevel;

    [Header("Pause Menu Configs")]
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;
    public Button saveButton;
    public Button mainMenu;

    [Header("Main Menu Configs")]
    private static MainMenu instance;
    public string version;
    public TextMeshProUGUI verText;
    public Button newGameButton;
    public Button loadButton;
    public Button quitButton;

    [Header("Level Gui Configs")]
    public TextMeshProUGUI gameLevelText;
    public TextMeshProUGUI totalPowerOutputText;
    public GameObject debugMenu;
    public Slider bar;
    public float barValue;
    public float barMaxValue;

    [Header("New Game Configs")]//New game config
    public float newGameTotalPowerOutput = 0.0f;
    public int newGameLevel = 1;
    //public int newPower = 0;
    public long newMoney = 100;

    [Header("(DEBUG) Data To Save:")]
    //CURRENT GAME DATA, THIS IS WHATS SAVED, YOU CAN SEE "GameData.cs" TO SEE DATA
    public float totalPowerOutput = 1f;
    [SerializeField] public int gameLevel;
    [SerializeField] public int gameLevelHist;
    [SerializeField] public long power;
    [SerializeField] public long powerHist;
    [SerializeField] public long money;
    [SerializeField] public long moneyHist;
    //public List<string> generators;


    void Start()
    {
        generatorHandler = FindAnyObjectByType<GeneratorHandler>();
        totalPowerOutput = generatorHandler.GetTotalProductionPerSecond();
        powerHist = (long) generatorHandler.totalGenPowerHist;

        debugMenu.SetActive(false);
        GameData data = SaveLoad.LoadData();
        activeMenu = true;
        activeLevel = false;
        levelObject.SetActive(false);
        menuObject.SetActive(true);
        verText.text = version;
        verText.faceColor = Color.red;
        newGameButton.onClick.AddListener(NewGame);
        loadButton.onClick.AddListener(LoadGame);
        quitButton.onClick.AddListener(QuitGame);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ContinueGame);
        mainMenu.onClick.AddListener(MainMenu);
        saveButton.onClick.AddListener(SaveGame);
        gameLevelText.text = "Lv:" + gameLevel;
        totalPowerOutputText.text = totalPowerOutput + "Kwh";
        bar.maxValue = barMaxValue;
        barValue = totalPowerOutput;
        money = ScoreManager.Instance.score;

    }
    void Update()
    {
        if (pauseMenu.activeSelf == false && levelObject.activeSelf == true)
        {
    
            totalPowerOutput = generatorHandler.GetTotalProductionPerSecond();
            UpdateLevel();
            totalPowerOutputText.text = totalPowerOutput + "Kwh";
            powerHist = (long) generatorHandler.totalGenPowerHist;
            //generatorHandler.UpdateTotalGenPowerHist();
            money = ScoreManager.Instance.score;
            moneyHist = ScoreManager.Instance.scoreHist;
            //Debug.Log(totalPowerOutput.ToString());
            barValue = totalPowerOutput;
        }
        if (Keyboard.current.eKey.wasPressedThisFrame && debugMenu.activeSelf == false)
        {
            Debug.Log("Debug Menu");
            debugMenu.SetActive(true);
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame && debugMenu.activeSelf == true)
        {
            Debug.Log("Debug Menu Closed");
            debugMenu.SetActive(false);
        }

        else return;


   
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
        Debug.Log($"Game Data is Saved.");


    }

    void MainMenu()
    {        

        activeMenu = true;
        activeLevel = false;
        menuObject.SetActive(true);
        StartCoroutine(Delay(0.01f)); // Safety Delay to ensure action is complete
        Time.timeScale = 1;
        pauseButton.gameObject.SetActive(true);
        pauseMenu.SetActive(false);
        levelObject.SetActive(false);

    }

    private IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Safety delay for pause game

    }

    void UpdateLevel()
    {
        if (barValue >= bar.maxValue)
        {    
            bar.value = totalPowerOutput - totalPowerOutput;
            bar.maxValue = (barMaxValue + barValue) * Mathf.Pow(1.25f, gameLevel);
            gameLevel = gameLevel + 1;
            gameLevelHist++;
            gameLevelText.text = "Lv:" + gameLevel;
            Debug.Log("LevelUp");
            return;
        }
        else if (barValue <= bar.maxValue)
        {
            bar.value = barValue;
            totalPowerOutputText.text = Mathf.Round(totalPowerOutput * 10.0f) + "Kwh";
            StartCoroutine(Delay(1.0f));
            gameLevelText.text = "Lv:" + gameLevel;

            return;
        }
    }


    public void NewGame()
    {
        activeMenu = false;
        activeLevel = true;
        menuObject.SetActive(false);
        levelObject.SetActive(true);

        //////////////////////////////////////////ISTANTIATE FRESH VALUES///////////////////////////////
        totalPowerOutput = newGameTotalPowerOutput;
        gameLevel = newGameLevel;
        // Temp foor gameLevelHist
        gameLevelHist = newGameLevel;
        power = 0;
        money = newMoney;
        ScoreManager.Instance.ResetScore();
        ScoreManager.Instance.AddScore(newMoney);
        gameLevelText.text = "Lv:" + gameLevel;
        generatorHandler.NewGameList();
            

    }

    public void LoadGame()
    {
        activeMenu = false;
        activeLevel = true;
        menuObject.SetActive(false);
        levelObject.SetActive(true);

        //////////////////////////////////////////ISTANTIATE FRESH VALUES///////////////////////////////CRUDE
        totalPowerOutput = newGameTotalPowerOutput;
        gameLevel = newGameLevel;
        power = 0;
        money = newMoney;
        ScoreManager.Instance.ResetScore();
        ScoreManager.Instance.AddScore(newMoney);
        gameLevelText.text = "Lv:" + gameLevel;


        if (SaveLoad.LoadData() == null) return;
        //Confirm that scene is loaded before loading game data

        //Debug.Log($"{levelObject} is loaded.");
        GameData data = SaveLoad.LoadData();
        gameLevel = data.gameLevel;
        gameLevelHist = data.gameLevelHist;
        power = data.power;
        powerHist = data.powerHist;
        money = data.money;
        moneyHist = data.moneyHist;

        ScoreManager.Instance.ResetScore();
        ScoreManager.Instance.AddScore(money);
        Debug.Log($"Game Data is loaded.");
        gameLevelText.text = "Lv:" + gameLevel;


    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


 


