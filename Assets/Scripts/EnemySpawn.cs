using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform levelRoot;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
       var enemy = Instantiate(Enemy, new Vector3(0f, 0f, 0f), levelRoot.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        //enenemyemy= Instantiate(Enemy, new Vector3(0f, 0f, 0f), levelRoot.rotation);
    }
}
