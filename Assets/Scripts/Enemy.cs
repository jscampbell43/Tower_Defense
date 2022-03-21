using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    public float speed = 3f;

    public int coins = 3;

    public List<Transform> waypointList;

    private int targetWayPoint = 1;
    private bool pastFirstWaypoint = false;
    
    // Delegate event for outside code to subscribe and be notified of enemy death
    public delegate void EnemyDied(Enemy deadEnemy);
    public event EnemyDied OnEnemyDied;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        // Set enemy position to first way point
        transform.position = waypointList[0].position;
        targetWayPoint = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Get position of next waypoint
        Vector3 targetPosition = waypointList[targetWayPoint].position;
        
        // Movement vector is target position vector - enemy position vector
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        // Get vector before updating position
        Vector3 targetDir = targetPosition - transform.position;
        // Update position
        transform.position += movementDir * speed * Time.deltaTime;
        // Get vector after updating position
        Vector3 updatedPosition = targetPosition - transform.position;
        // If target direction and new position are facing eachother
        if (Vector3.Dot(targetDir, updatedPosition) < 0)
        {
            // Update waypoint index to Move Enemy towards next waypoint
            targetWayPoint++;
            Debug.Log("targetWayPoint index: " + targetWayPoint);
        }
        
        /*// If enemy dies fire event
        bool enemyDied = false;
        if (enemyDied)
        {
            OnEnemyDied.Invoke(this);
        }*/
        
        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Mouse Clicked");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f)){
                Debug.Log("Object selected: " + hit.transform.name);
                // If brick is clicked: Destroy brick
                if(hit.transform.name == "Enemy")
                {
                    health--;
                    Debug.Log("Health: " + health);
                    if (health == 0)
                    {
                        OnEnemyDied.Invoke(this);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
