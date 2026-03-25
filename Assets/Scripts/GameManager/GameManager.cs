using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;
    public Button saveButton;
    //public Button loadButton;
    public Button mainMenu;
    public string menu;



    //GAME DATA
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

        LoadGame(); //FORCE LOAD, I HAVE YET TO SORT LOAD ON SCENE CHANGE, WILL ADRESS IN UPCOMING COMIT
    }
    void Update()
    {
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

    
}