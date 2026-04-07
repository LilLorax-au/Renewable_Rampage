using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabToggler : MonoBehaviour
{
    
    [SerializeField] public List<GameObject> tabs = new List<GameObject>();
    
    [SerializeField] public List<GameObject> buttons = new List<GameObject>();

    private GameObject currentTab;
    public Color buttonColor;

    void Start()
    {
        SetTab(tabs[0]);
        SetBtn(buttons[0]);
    }
    public void SetTab(GameObject tab)
    {
        currentTab = tab;
        // Hides other tabs
        foreach (var t in tabs)
        {
            t.transform.localScale = new Vector3(0, 0, 0);
        }
        currentTab.transform.localScale = new Vector3(1, 1, 1);
    }

    public void SetBtn(GameObject btn)
    {
        // Disables the current tab's button
        foreach (var button in buttons)
        {
            button.GetComponent<Button>().interactable = true;
            button.GetComponent<Image>().color = buttonColor;
        }
        btn.GetComponent<Button>().interactable = false;
        btn.GetComponent<Image>().color = Color.deepSkyBlue;
    }

    public GameObject GetCurrentTab()
    {
        return currentTab;
    }
}