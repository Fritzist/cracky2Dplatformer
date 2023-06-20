using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;

    }
}
