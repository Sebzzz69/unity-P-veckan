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
    public float health { get; private set; }

    public int hitPoints { get; private set; }
    public int killPoints { get; private set; }

    Vector2 movement;
    Rigidbody2D rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        enemySpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        //transform.position += transform.up * enemySpeed * Time.deltaTime;
        rigidbody.velocity = new Vector2(0f, enemySpeed);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            //enemySpeed = Random.Range(minSpeed, maxSpeed);
            enemySpeed = -enemySpeed;
        }
    }

}
