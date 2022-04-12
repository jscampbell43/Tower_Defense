using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortBehavior : MonoBehaviour
{
    public float health = 100;
	public GameObject canvas;
	public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Fort health Start: " + health);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Damage()
    {
        health -= 20;
        Debug.Log("Fort health: " + health);
        if (health <= 0)
        {
      
      
            Debug.Log($"{transform.name} is Dead");
            // Trigger Enemy Death Event in HordeManager
			GameObject newButton = Instantiate(restartButton);
			newButton.transform.SetParent(canvas.transform, false);
            Destroy(this.gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Fort health: " + health);
        Debug.Log(collision.gameObject.name + " was what hit Fort");
        Damage();
    }
}
