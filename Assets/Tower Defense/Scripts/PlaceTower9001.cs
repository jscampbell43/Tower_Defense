using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower9001 : MonoBehaviour
{
  public GameObject Tower;
  //public static Transform 
  
  public GameObject World;

  public static int numberOfTowers = 0;


	//public static Transform targeTower; 
    // Start is called before the first frame update
    void Start()  
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
          if (hit.transform.tag == "TowerSpot")
          {
            // Check CoinPurse variable to see if at least 5 coins are available
            if (CoinPurse.currentCoins >= 2)
            {
              //Book keeping
              // if good and if enough coins place Tower and reduce coins by 5
              hit.transform.gameObject.SetActive(false);
              PlaceTower(hit.transform.position);
              CoinPurse.currentCoins = CoinPurse.currentCoins - 1;
              numberOfTowers += 1;
            }
          }
        else
          print("I'm looking at nothing!");
        
    }

    //raycast
    //hitplace
    //purse script $$$$
    //instantiate a tower

  }

    void PlaceTower(Vector3 position)
    {
      //Book keeping
      Instantiate(Tower, position, Quaternion.identity, World.transform);
		//targeTower = GameObject.Find("Tower(Clone)").transform;
    }
}
