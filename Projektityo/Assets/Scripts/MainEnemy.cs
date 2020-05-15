using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEnemy : MonoBehaviour
{
    public GameObject bullet;

    public int health = 100;
    
    public float speed = 1;

    private float gameTime;

    private Collider2D enemyCollision;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        gameTime += Time.deltaTime;
        transform.Translate(Vector2.down * (speed * Time.deltaTime));

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (gameTime > .03)
        {
            BulletScript();
            gameTime -= 1;
        }
        
    }

    public void BulletScript()
    {
        Instantiate(bullet, new Vector2(transform.position.x , transform.position.y) , Quaternion.Euler(0,0, 180));
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("PlayerBullet")) return;
        health--;
        Debug.Log(health);
        Destroy(other.gameObject);
    }
}
