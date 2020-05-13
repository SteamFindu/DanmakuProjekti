using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InitialScript : MonoBehaviour
{
    public float gameTime;
    public void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
    }
}
