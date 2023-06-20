using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    public int coinCounter;
    public Text counter;

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = coinCounter.ToString();
    }
    public void AddCoin()
    {
        coinCounter++;
        PlayerPrefs.SetInt("Coins", coinCounter);
    }
}
