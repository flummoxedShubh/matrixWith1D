using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   // public GameObject MainCamera;

    public AudioClip clipLazer;
    public AudioClip clipCollision;

    public AudioSource audioSource;

    public static int score = 0;

    public Transform enemySpawn;
    public ParticleSystem ParticleExplosion;

    public float bulletSpeed = 5f;

    private void Awake()
    {
        enemySpawn = GameObject.FindGameObjectWithTag("Enemy").transform;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(clipLazer);
       // MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
       
    }

    void Update()
    {
        BulletMove();
        if(score == 50)
        {
            EnemyMovement.enemySpeed = 5f;
        }
        else if (score == 100)
        {
            EnemyMovement.enemySpeed = 7f;
        }
    }

   /* public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = MainCamera.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            MainCamera.transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;

            yield return null; //Wait until next frame is drawn
        }
        MainCamera.transform.localPosition = originalPos;
    }
    */  
    void BulletMove()
    {
        Vector3 direction = enemySpawn.position - transform.position;
        transform.Translate(direction.normalized * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Enemy0" && gameObject.tag == "Player0")
        {
            //StartCoroutine(Shake(.15f, .4f));
            audioSource.PlayOneShot(clipCollision);
            Instantiate(ParticleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            score++;
        }
        else if (collision.gameObject.tag == "Enemy1" && gameObject.tag == "Player0")
        {
            //StartCoroutine(Shake(.15f, .4f));
            audioSource.PlayOneShot(clipCollision);
            Instantiate(ParticleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            score--;
        }
        else if (collision.gameObject.tag == "Enemy1" && gameObject.tag == "Player1")
        {
            //StartCoroutine(Shake(.15f, .4f));
            audioSource.PlayOneShot(clipCollision);
            Instantiate(ParticleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            score++;
        }
        else if (collision.gameObject.tag == "Enemy0" && gameObject.tag == "Player1")
        {
            //StartCoroutine(Shake(.15f, .4f));
            audioSource.PlayOneShot(clipCollision);
            Instantiate(ParticleExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            score--;
        }

    }
}
