using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

   /*
    *  
    *  - bullets gettings stuck in the air 
    *   when hitting an obstacle after bocuing back on obstacle before
   */


    [SerializeField] float score;
    int level = 1;

     Player player;
    public Bullet bullet { get; private set; }
    public Enemy enemy { get; private set; }

    Enemy enemyEnemy;

    SceneHandler nextScene;

    string currentSceneName;
    Scene curretScene;

    // UI Text Objects
    [Header("Text Objects")]
    //public GameObject textMeshProScore;
    TextMeshProUGUI scoreTxt;
    
    Weapon weapon;

    private void Awake()
    {

        IfMoreGameManagers();
          //  DontDestroyOnLoad(this);

        // UI Text
        //scoreTxt = textMeshProScore.GetComponent<TextMeshProUGUI>();
        
    }

    private void Start()
    {

        //Player player;
        //scoreTxt.text = $"Score: {score}";

       // SceneManager.LoadScene("MainMenu");

        NewGame();
    }

    private void Update()
    {

        //scoreTxt.text = $"Score: {score}";
        curretScene = SceneManager.GetActiveScene();
        currentSceneName = curretScene.name;
            if (score >= 55)
            {
                level++;
                if (level >= 4)
                {
                    SceneManager.LoadScene("WinScreen");
                }
                else
                {
                    SceneManager.LoadScene($"Level{level}");
                }

                NewGame();


            }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("MainMenu");
            score = 0;
        }

        // Cheat
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene($"Level{level + 1}");
            level++;
        }

    }

    private void IfMoreGameManagers()
    {
        int numGameManagers = FindObjectsOfType<GameManager>().Length;
        if (numGameManagers != 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void EnemyHit(Enemy enemy)
    {
        Debug.Log("Enemy Hit");

        enemy.health -= 5;
        score += enemy.hitPoints;

        if (enemy.health <= 0)
        {
            Destroy(enemy.gameObject);
            score += enemy.killPoints - enemy.hitPoints;
        }
    }

    public void PlayerHit(Player player)
    {
        Debug.Log("Player Hit");
        player.health--;


        if (player.health <= 0)
        {
            SceneManager.LoadScene("Level1");
            score = 0;
            level = 1;


        }
    }

    private void NewGame()
    {
        score = 0;
       /* player.ResetPlayer();
        enemy.ResetEnemy();*/
    }

    

}
