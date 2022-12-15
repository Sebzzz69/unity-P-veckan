using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMusicScript : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField] AudioClip gamePlay;


    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<GamePlayMusicScript>().Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = gamePlay;
        audioSource.Play();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            audioSource.mute = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            audioSource.mute = false;
        }

        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Destroy(this.gameObject);
        }
    }

}
