using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounterEndless : MonoBehaviour
{

    public int deadEnemys;
    public Text counter;

    // Start is called before the first frame update
    void Start()
    {
        deadEnemys = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        
        counter.text = deadEnemys.ToString() + " Enemies survived";
    }

    public void EnemyDead()
    {
        deadEnemys++;   
        PlayerPrefs.SetInt("Enemies", deadEnemys);
    }
}