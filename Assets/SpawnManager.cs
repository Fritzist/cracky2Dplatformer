using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;

    public float intervall;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, intervall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Spawn()
    {
        Instantiate(enemy, transform.position + new Vector3(Random.Range(-5,1),0,0), transform.rotation);
    }
}
