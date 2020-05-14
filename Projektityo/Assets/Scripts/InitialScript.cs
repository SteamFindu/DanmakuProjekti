using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InitialScript : MonoBehaviour
{
    private float gameTime;
    public static int _realTime;
    public void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > 1)
        {
            gameTime -= 1;
            _realTime += 1;
        }
        
        Debug.Log(_realTime);
    }
}
