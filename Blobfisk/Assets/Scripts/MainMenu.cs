using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    MusicScript musicScript;
    [SerializeField] GameObject menuUI;
    [SerializeField ]GameObject creditUI;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CreditsMenu()
    {
        menuUI.SetActive(false);
        creditUI.SetActive(true);

    }

    public void BackFromCredits()
    {
        creditUI.SetActive(false);
        menuUI.SetActive(true);
    }
}
