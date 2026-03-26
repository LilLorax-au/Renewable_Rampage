using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor.Build.Reporting;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private static MainMenu instance;
    public GameObject menuObject;
    public GameObject levelObject;
    public TextMeshProUGUI version;
    public Button newGameButton;
    public Button loadButton;
    public Button quitButton;

    public bool activeMenu;
    public bool activeLevel;

    //void awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeMenu = true;
        GetVersion();
        newGameButton.onClick.AddListener(LoadGame);
        loadButton.onClick.AddListener(LoadGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }

    public void LoadGame()
    {
        if (activeMenu == true)
        {
            activeMenu = true;
            activeLevel = false;
            menuObject.SetActive(true);
            levelObject.SetActive(false);
        }
        else if (activeLevel == true)
        {
            activeMenu = false;
            activeLevel = true;
            menuObject.SetActive(false);
            levelObject.SetActive(true);

            //Confirm that scene is loaded before loading game data

            Debug.Log($"{levelObject} is loaded.");
            GameData data = SaveLoad.LoadData();
            Debug.Log($"Game Data is loaded.");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void GetVersion()
    {
        version.text =  Application.version;
    }

}
