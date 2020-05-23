using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float health = 2f;

    public static int EnemiesAlive = 0;

    public string loadLevel;
    private void Start()
    {
        EnemiesAlive++;
    }
    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if(colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        EnemiesAlive--;
        if(EnemiesAlive <= 0)
        {
            //Debug.Log("Player!!");
            SceneManager.LoadScene(loadLevel);
        }
        Destroy(gameObject);
    }

  
}
