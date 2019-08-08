using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform PlayerSpawn;
    public static int Lives = 1;

    public static float enemySpeed = 3f;

    private void Awake()
    {
        PlayerSpawn = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        EnemyMove();
    }

    void EnemyMove()
    {
        Vector3 direction = PlayerSpawn.position - transform.position;
        transform.Translate(direction.normalized * enemySpeed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Lives--;
            Destroy(gameObject);
            Debug.Log("Object Destroyed!");
        }
    }
}
