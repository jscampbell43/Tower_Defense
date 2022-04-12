using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class HordeManager : MonoBehaviour
{

  public Wave enemyWave;
  public Path enemyPath;

	public static Transform targetEnemy; 

  //Delegate for alerting CoinPurse that an Enemy has died
  public delegate void HordeEnemyDestroyedDelegate();

  public event HordeEnemyDestroyedDelegate hordeEnemyDestroyedEvent;

private int numOfEnemies = 0;
public GameObject canvas;
	public GameObject restartButton;
  
  IEnumerator Start()
  {

    Debug.Log("before spawn small");
    StartCoroutine("SpawnSmallEnemies");
    StartCoroutine("SpawnBigEnemies");

    yield break;

  }

	void Update(){
	targetEnemy = GameObject.Find("SmallBadGuy(Clone)").transform;
}

  //pick our enemy to spawn
  //spawn it
  //wait
  IEnumerator SpawnSmallEnemies()
  {
    for (int i = 0; i < enemyWave.groupsOfEnemiesInWave.Length; i++)
    {

      for (int j = 0; j < enemyWave.groupsOfEnemiesInWave[i].numberOfSmall; j++)
      {
        Enemy spawnedEnemy = Instantiate(enemyWave.groupsOfEnemiesInWave[i].smallMichaelEnemy).GetComponent<Enemy>();
        numOfEnemies++;
		Debug.Log(numOfEnemies + " Enemies");
		// Subscribe OnEnemyDestroyed function for each Enemies enemyDestroyedEvent
        FindObjectOfType<Enemy>().enemyDestroyedEvent += OnEnemyDestroyed;
        targetEnemy = GameObject.Find("SmallBadGuy(Clone)").transform;
		spawnedEnemy.route = enemyPath;
        yield return new WaitForSeconds(enemyWave.groupsOfEnemiesInWave[i].coolDownBetweenSmallEnemies);

      }

      yield return new WaitForSeconds(enemyWave.coolDownBetweenSmallWave); // cooldown between groups
    }

    Debug.Log("done with small");

  }

  IEnumerator SpawnBigEnemies()
  {
    Debug.Log("big bad");
    yield return null;
  }
  
  public void OnEnemyDestroyed()
  {
    Debug.Log("Told Horde that enemy was destroyed");
    // Trigger Enemy Death Event in CoinPurse
	numOfEnemies--;
	if(numOfEnemies == 0){
		// Instantiate restart button
		GameObject newButton = Instantiate(restartButton);
		newButton.transform.SetParent(canvas.transform, false);
	}
    hordeEnemyDestroyedEvent();
  }
}



[Serializable]
public struct Group
{
  public GameObject smallMichaelEnemy;
  public GameObject bigAwesomeSuperBadGuyClayEnemy;
  public int numberOfSmall;
  public int numberOfLarge;
  public float coolDownBetweenSmallEnemies;
  public float coolDownBetweenLargeEnemies;
}

[Serializable]
public struct Wave
{
  public Group[] groupsOfEnemiesInWave;
  public float coolDownBetweenSmallWave;
  public float coolDownBetweenLargeWave;
}

