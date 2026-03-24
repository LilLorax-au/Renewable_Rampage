using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static MainMenu instance;
    public string mainLevel;
    public string loadLevel;

    public Button newGameButton;
    public Button loadButton;
    public Button quitButton;

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
        newGameButton.onClick.AddListener(LoadLevel);
      //  loadButton.onClick.AddListener(loadGame);
        quitButton.onClick.AddListener(QuitGame);


        
    }

    // Update is called once per frame
    void Update()
    {
        return;
    }
    
    public void LoadLevel()
    {
        SceneManager.LoadScene(mainLevel);
        
    }

    //void loadGame()
    //{
    //    SceneManager.LoadScene(mainLevel);

    //    Scene scene = SceneManager.GetSceneByName(mainLevel); //Confirm that scene is loaded before loading game data
    //    Debug.Log($"{mainLevel} is loaded.");
        
    //    GameData data = SaveLoad.LoadData();
    //    Debug.Log($"Game Data is loaded.");
    //    //this.gameObject.SetActive(false);

    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
