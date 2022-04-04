using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPurse : MonoBehaviour
{
    public TextMeshProUGUI guiText;
    public static int currentCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe enemyDestroyedScore function to HordeManager hordeEnemyDestroyedEvent
        FindObjectOfType<HordeManager>().hordeEnemyDestroyedEvent += enemyDestroyedScore;
    }

    // Update is called once per frame
    void Update()
    {
        // Update GUI constantly for when coins are spent
        guiText.text = "Purse: " + currentCoins;
        // When Space is pressed add coin (For testing)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            currentCoins++;
            guiText.text = "Purse: " + currentCoins;
        }
    }

    // When HordManager signals an enemy was destroyed update current coins
    public void enemyDestroyedScore()
    {
        Debug.Log("Score Told that enemy was destroyed");
        currentCoins++;
        guiText.text = "Purse: " + currentCoins;
    }
}
