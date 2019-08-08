using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform Bullet0;
    public Transform Bullet1;

    private float offset = 1f;
    
    void Update()
    {
        PlayerShoot();
    }

    void PlayerShoot()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(Bullet1, new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(Bullet0, new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
