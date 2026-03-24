using UnityEngine;
using UnityEngine.UI;

public class PauseGameManager : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public Button pauseButton;
    public Button resumeButton;


    void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ContinueGame);
    }
    void Update()
    {
        return;
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        //enable the scripts again
    }
}