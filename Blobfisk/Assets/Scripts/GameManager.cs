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

   // float playerHealth;
    [SerializeField] float score;
    int level = 1;

     Player player;
    public Bullet bullet { get; private set; }
    public Enemy enemy { get; private set; }

    SceneHandler nextScene;

    string currentSceneName;
    Scene curretScene;

    // UI Text Objects
    [Header("Text Objects")]
    public GameObject textMeshProScore;
    public GameObject textMeshProHealth;

    TextMeshProUGUI scoreTxt;
    TextMeshProUGUI healthTxt;

    Weapon weapon;

    private void Awake()
    {
            DontDestroyOnLoad(this);

        // UI Text
        scoreTxt = textMeshProScore.GetComponent<TextMeshProUGUI>();
        healthTxt = textMeshProHealth.GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {

        //Player player;
       // healthTxt.text = $"Health:" + player.health;
        scoreTxt.text = $"Score: {score}";

       // SceneManager.LoadScene("MainMenu");

        NewGame();
    }

    private void Update()
    {

        scoreTxt.text = $"Score: {score}";
        curretScene = SceneManager.GetActiveScene();
        currentSceneName = curretScene.name;
        /*if (currentSceneName == $"Level{level}")
        {
        }*/
            if (score >= 60)
            {
                level++;
                if (level >= 6)
                {
                    SceneManager.LoadScene("WinScreen");
                }
                else
                {
                    SceneManager.LoadScene($"Level{level}");
                }

                NewGame();


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
       // healthTxt.text = $"Health: {player.health}";


        if (player.health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);


        }
    }

    private void NewGame()
    {
        score = 0;
       /* player.ResetPlayer();
        enemy.ResetEnemy();*/
    }

    /*private void GameOver()
    {
        ResetLevel(player, enemy);
        score = 0;
    }*/

    

}
