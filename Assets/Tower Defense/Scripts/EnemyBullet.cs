using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 5;
    //public Transform Tower;
    //private GameObject target;

    //-----------------------------------------------------------------------------
    void Start()
    {
        Fire();
    }

    //-----------------------------------------------------------------------------
    private void Fire()
    {
        Transform target = HordeManager.targetEnemy;
        Debug.DrawLine (target.transform.position, this.transform.position, Color.red, Mathf.Infinity);
        Vector3 dir = (target.transform.position - this.transform.position).normalized;
        GetComponent<Rigidbody>().velocity = dir * speed;
        Debug.Log("Wwweeeeee");
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
