using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPathThroughLife;
  public int coinWorth;
  public float health = 100;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop = false;
  private float healthPerUnit;

  public Transform healthBar;
public GameObject explodeParticle;
  
  //public GameObject bullet;
  //public Transform shootingOffset;
  //private float accumulatedTime = 0f;
  //private float totalTime = 0f;
  //private bool towersPlaced = false;
  
  //Delegate for alerting HordeManager that an Enemy has died
  public delegate void EnemyDestroyedDelegate();

  public event EnemyDestroyedDelegate enemyDestroyedEvent;

  void Start()
  {
    healthPerUnit = 100f / health;

    myPathThroughLife = route.path;
    transform.position = myPathThroughLife[index].transform.position;
    Recalculate();
  }

  void Update()
  {
    if (!stop)
    {
      if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
      {
        index = index + 1;
        Recalculate();
      }
      
      Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
      transform.Translate(moveThisFrame);
    }

    /*if (PlaceTower9001.numberOfTowers > 0)
    {
      towersPlaced = true;
    }*/
    
    /*// Fire at a random time interval
    accumulatedTime += Time.deltaTime;
    if (accumulatedTime > Random.Range(0f, 3f) && towersPlaced)
    {
      totalTime += 1f;
      accumulatedTime = 0f;
      GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
      Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
      Debug.Log("Bang!");
      Destroy(shot, 10f);
    }*/

  }

  void Recalculate()
  {
    if (index < myPathThroughLife.Length -1)
    {
      nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position).normalized;

    }
    else
    {
      stop = true;
    }
  }

  public void Damage()
  {
    health -= 20;
    if (health <= 0)
    {
      
      
      Debug.Log($"{transform.name} is Dead");
      // Trigger Enemy Death Event in HordeManager
      enemyDestroyedEvent();
		// Transform enemy into particle system
		Instantiate(explodeParticle, this.transform.position, Quaternion.identity);
		//Destroy(explodeParticle.gameObject, 1.0f);
      Destroy(this.gameObject);
    }

    float percentage = healthPerUnit * health;
    Vector3 newHealthAmount = new Vector3(percentage/100f , healthBar.localScale.y, healthBar.localScale.z);
    healthBar.localScale = newHealthAmount;
  }

	public void OnCollisionEnter(Collision collision)
    {
		if(collision.gameObject.name == "Bullet(Clone)"){
			Damage();
		}
		else{
			Destroy(gameObject);
		}
    }

}
