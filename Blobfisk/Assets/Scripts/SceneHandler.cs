using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class SceneHandler : MonoBehaviour
{

    [SerializeField] int level = 1;

    private void Awake()
    {
        DontDestroyOnLoad(this); 

    }
    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        LoadLevel(level);
    }

    public void LoadLevel(int level)
    {
        this.level = level;

        if (this.level > 5)
        {
           // SceneManager.LoadScene("WinScreen");
        }      

        SceneManager.LoadScene($"Level{level}");
    }

}
