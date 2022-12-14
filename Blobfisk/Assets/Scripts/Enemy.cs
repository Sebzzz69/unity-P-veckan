using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.Profiling;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float enemySpeed;
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float minSpeed = 4;
    [SerializeField] int enemyHealth = 20;
    public float health { get; set; }


    public int hitPoints { get; private set; } = 5;
    public int killPoints { get; private set; } = 15;

    Vector2 movement;
    Rigidbody2D rigidbody;
    GameManager manager;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        enemySpeed = Random.Range(minSpeed, maxSpeed);

        health = enemyHealth;
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        rigidbody.velocity = new Vector2(0f, enemySpeed);
        
    }

    public void ResetEnemy()
    {
        this.transform.position = new Vector2(this.transform.position.x, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            //enemySpeed = Random.Range(minSpeed, maxSpeed);
            enemySpeed = -enemySpeed;
        }
        if (collision.gameObject.CompareTag("Enemy"))
            enemySpeed = -enemySpeed;
    }


}
