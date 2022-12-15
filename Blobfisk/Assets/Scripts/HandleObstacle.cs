using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class HandleObstacle : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] int maxHeight;
    [SerializeField] int minHeight;

     float speed;
     int height;

   // Transform transform;
    Rigidbody2D rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
       // transform = GetComponent<Transform>();
    }
    private void Start()
    {
        SetObstacleProperties();

        //Debug.Log("Height" + height);
        //Debug.Log("Speed:" + speed);

    }

    private void FixedUpdate()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        rigidbody.velocity = new Vector2(0f, speed);
    }

    private void SetObstacleProperties()
    {
        speed = Random.Range(minSpeed, maxHeight);
        height = Random.Range(minHeight, maxHeight);

        gameObject.transform.localScale = new Vector2(0.5f, height);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            speed = -speed;
        }
        else if (collision.gameObject.CompareTag("Obstecle"))
        {
            speed = -speed;
        }
        
    }


}
