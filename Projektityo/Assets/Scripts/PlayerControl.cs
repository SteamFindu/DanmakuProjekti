using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PlayerControl : MonoBehaviour
{
    private float speed;
    
    private float xBoundry = 4.5f;

    private float yBoundry = 3.8f;

    private float frameTime;

    public GameObject projectile;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
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
                Instantiate(projectile, new Vector2(transform.position.x + 0.3f, transform.position.y) , projectile.transform.rotation);
                Instantiate(projectile, new Vector2(transform.position.x - 0.3f, transform.position.y) , projectile.transform.rotation);
                frameTime = 0;
            }
        }

        Debug.Log(frameTime);    
        
        transform.Translate(Vector2.right * (horizontalInput * speed * Time.deltaTime));
        transform.Translate(Vector2.up * (verticalInput * speed * Time.deltaTime));

    }
}
