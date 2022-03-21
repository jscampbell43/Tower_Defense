using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Economy : MonoBehaviour
{
    public TextMeshProUGUI inGameText;
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Enemy>().OnEnemyDied += ReactEnemyDied;
    }

    // Update is called once per frame
    void Update()
    {
        inGameText.text = "Coins: " + coins;
    }

    public void ReactEnemyDied(Enemy enemy)
    {
        Debug.Log("Enemy hit: " + enemy);
        coins++;
    }
}
