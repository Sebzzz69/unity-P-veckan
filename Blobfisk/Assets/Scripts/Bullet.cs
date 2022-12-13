using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    public Rigidbody2D rigidbody;

    Player player;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rigidbody.velocity = transform.right * speed;
    }


    private void DestroyBullet()
    {
        if (this != null)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstecle"))
        {
            rigidbody.velocity = -transform.right * speed;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyBullet();
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            FindObjectOfType<GameManager>().EnemyHit(enemy);
            DestroyBullet();
        }
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            FindObjectOfType<GameManager>().PlayerHit(player, enemy);
            DestroyBullet();
        }



    }
}
