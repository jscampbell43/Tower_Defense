using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingOffset;
    private float accumulatedTime = 0f;
    private float totalTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Fire at a random time interval
        accumulatedTime += Time.deltaTime;
        if (accumulatedTime > Random.Range(0f, 3f))
        {
            totalTime += 1f;
            accumulatedTime = 0f;
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
            Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
            Debug.Log("Bang!");
            Destroy(shot, 1f);
        }
    }
}
