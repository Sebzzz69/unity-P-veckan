using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    float playerHealth;
    [SerializeField] float score;

    Player player;
    Bullet bullet;

    private void Awake()
    {
            DontDestroyOnLoad(this);
    }

    private void Start()
    {
    }

    private void Update()
    {
        
        if (score >= 30)
        {
            // Next level or you win idk yet
        }
    }

    public void EnemyHit(Enemy enemy)
    {
        score += 10f;

        enemy.health -= 5;

        if (enemy.health <= 0)
        {
            Destroy(enemy.gameObject);
        }
    }

    public void PlayerHit(Player player)
    {
        player.health--;

        if (player.health <= 0)
        {
            player.ResetPlayer();
        }
    }


}
