using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagement : MonoBehaviour
{
    public GameObject basicEnemy;

    private int maxAmm = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InitialScript._realTime == 5 && maxAmm == 1)
        {
            Instantiate(basicEnemy,new Vector2(0, 5) , basicEnemy.transform.rotation);
            maxAmm++;
        }
    }
}
