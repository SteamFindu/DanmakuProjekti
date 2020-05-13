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
    public float playerLevel = 1;

    public GameObject projectile;
    public GameObject levelProjectile;
    
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
            speed = 3;
            
        }
        else
        {
            speed = 10;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (frameTime > .07)
            {
                ShootStuff();
                frameTime = 0;
            }
        }

        Debug.Log(frameTime);    
        
        transform.Translate(Vector2.right * (horizontalInput * speed * Time.deltaTime));
        transform.Translate(Vector2.up * (verticalInput * speed * Time.deltaTime));
        
        
    }

    private void ShootStuff()
    {
        Instantiate(projectile, new Vector2(transform.position.x + 0.3f, transform.position.y) , projectile.transform.rotation);
        Instantiate(projectile, new Vector2(transform.position.x - 0.3f, transform.position.y) , projectile.transform.rotation);
        
        Instantiate(levelProjectile, new Vector2(transform.position.x + 0.3f, transform.position.y) , Quaternion.Euler(0,0, -20));
        Instantiate(levelProjectile, new Vector2(transform.position.x - 0.3f, transform.position.y) , Quaternion.Euler(0,0, 20));
        
    }
}
