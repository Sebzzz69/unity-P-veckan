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

     Player player;
    public Bullet bullet { get; private set; }
    public Enemy enemy { get; private set; }

    // UI Text Objects
    [Header("Text Objects")]
    public GameObject textMeshProScore;
    public GameObject textMeshProHealth;

    TextMeshProUGUI scoreTxt;
    TextMeshProUGUI healthTxt;

    private void Awake()
    {
            DontDestroyOnLoad(this);

        //SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void Start()
    {
        // UI Text
        scoreTxt = textMeshProScore.GetComponent<TextMeshProUGUI>();
        healthTxt = textMeshProHealth.GetComponent<TextMeshProUGUI>();

        //Player player;
       // healthTxt.text = $"Health:" + player.health;
        scoreTxt.text = $"Score: {score}";

       // NewGame();
    }

    private void Update()
    {

        scoreTxt.text = $"Score: {score}";
        

        if (score >= 30)
        {
            // Next level or you win idk yet
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

    public void PlayerHit(Player player, Enemy enemy)
    {
        Debug.Log("Player Hit");
        player.health--;
       // healthTxt.text = $"Health: {player.health}";


        if (player.health <= 0)
        {
            player.ResetPlayer();
            score = 0;


        }
    }

    /*private void GameOver()
    {
        ResetLevel(player, enemy);
        score = 0;
    }

    private void ResetLevel(Player player, Enemy enemy)
    {
        
    }*/

   /* private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.enemy = FindObjectOfType<Enemy>();
        this.player = FindObjectOfType<Player>();
    }*/


}
