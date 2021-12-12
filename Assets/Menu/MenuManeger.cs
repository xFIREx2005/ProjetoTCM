using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManeger : MonoBehaviour
{
    public string cena;
    public GameObject optionsPanel, volumePanel, menuPanel, controlsPanel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void QuitGame()
    {
       
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(cena);
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        volumePanel.SetActive(false);
         menuPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        if(menuPanel != null)menuPanel.SetActive(true);

        optionsPanel.SetActive(false);
        volumePanel.SetActive(false);
        controlsPanel.SetActive(false);
    }

    public void ShowVolume()
    {
        optionsPanel.SetActive(false);
        volumePanel.SetActive(true);
        menuPanel.SetActive(false);
        controlsPanel.SetActive(false);
    }
    public void ShowControls()
    {
        optionsPanel.SetActive(false);
        controlsPanel.SetActive(true);
        volumePanel.SetActive(false);
        menuPanel.SetActive(false);
    }
}
