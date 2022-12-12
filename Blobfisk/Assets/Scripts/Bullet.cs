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
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().PlayerHit(FindObjectOfType<Player>());
            DestroyBullet();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            FindObjectOfType<GameManager>().EnemyHit(FindObjectOfType<Enemy>());
            DestroyBullet();
        }
        else if (collision.gameObject.CompareTag("Obstecle"))
        {
            rigidbody.velocity = -transform.right * speed;
        }
        else
        {
            DestroyBullet();
        }
    }
}
