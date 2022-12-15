using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip mainMenu;
    [SerializeField] AudioClip gamePlay;

    //[SerializeField] bool destoryObject;

    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicScript>().Length;
        if (numMusicPlayers != 1)
        {
            Destroy(this.gameObject);
        }
        
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.clip = mainMenu;
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

        if (Input.GetKeyDown(KeyCode.H))
        {
            Destroy(this.gameObject);
        }



    }

}
