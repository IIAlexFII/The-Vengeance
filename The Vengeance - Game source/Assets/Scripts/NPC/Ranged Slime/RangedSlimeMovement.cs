using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlimeMovement : MonoBehaviour
{
    //missiong the change of direction for the animations
    private GameObject target; // player
    public float moveForce = 2;
    public float maxrange = 9;
    public float minrange = 0.75f; // so that the enemy doesn't push the player
    private Vector3 homePosition;

    void Start()
    {
        homePosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= maxrange && Vector3.Distance(transform.position, target.transform.position) >= minrange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(transform.position, target.transform.position) >= maxrange)
        {
            GoStartingPos();
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveForce * Time.deltaTime);
    }

    public void GoStartingPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, homePosition, moveForce * Time.deltaTime);
        
    }

}
