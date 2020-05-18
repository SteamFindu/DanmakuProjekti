using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerControl : MonoBehaviour
{
    private float speed;
    
    private float xBoundry = 5.2f;

    private float yBoundry = 3.8f;

    private float frameTime;
    private float zRotation;
    public float playerLevel = 1;

    public GameObject projectile;
    public GameObject levelProjectile;
    public GameObject hitbox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        frameTime += Time.deltaTime;
        
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if (transform.position.x > xBoundry)
        {
            transform.position = new Vector2(xBoundry, transform.position.y);
        } 
        if (transform.position.x < -xBoundry)
        {
            transform.position = new Vector2(-xBoundry, transform.position.y);
        }

        if (transform.position.y > yBoundry)
        {
            transform.position = new Vector2(transform.position.x, yBoundry);
        }
        if (transform.position.y < -yBoundry)
        {
            transform.position = new Vector2(transform.position.x, -yBoundry);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 4;
            zRotation = 7;
            hitbox.SetActive(true);
        }
        else
        {
            speed = 10;
            zRotation = 20;
            hitbox.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (frameTime > .07)
            {
                ShootStuff();
                frameTime = 0;
            }
        }
        
        transform.Translate(Vector2.right * (horizontalInput * speed * Time.deltaTime));
        transform.Translate(Vector2.up * (verticalInput * speed * Time.deltaTime));
        
        
    }

    private void ShootStuff()
    {
        Instantiate(projectile, new Vector2(transform.position.x + 0.3f, transform.position.y) , projectile.transform.rotation);
        Instantiate(projectile, new Vector2(transform.position.x - 0.3f, transform.position.y) , projectile.transform.rotation);
        
        Instantiate(levelProjectile, new Vector2(transform.position.x + 0.3f, transform.position.y) , Quaternion.Euler(0,0, -zRotation));
        Instantiate(levelProjectile, new Vector2(transform.position.x - 0.3f, transform.position.y) , Quaternion.Euler(0,0, zRotation));
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("got hit");
            OnDeath();
        }
    }
    // TODO remove all collisions and use triggers instead
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("got hit enemy");
            OnDeath();
        }
    }

    private void OnDeath()
    {
        // TODO create script that kills the player and respawns them

    }
}
