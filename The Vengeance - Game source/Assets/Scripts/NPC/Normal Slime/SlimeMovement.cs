using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    private SlimeLife slimelife;
    private GameObject target; // player

    public float moveForce = 2;
    public float maxrange = 9;
    public float minrange = 0.75f; // so that the enemy doesn't push the player

    private int pointsIndex;
    private Vector3 homeposition;

    private bool followActive;


    // Start is called before the first frame update
    void Start()
    {
        followActive = false;
        target = GameObject.FindGameObjectWithTag("Player");
        homeposition = transform.position;
        slimelife = gameObject.GetComponent<SlimeLife>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) <= maxrange && Vector3.Distance(transform.position, target.transform.position) >= minrange && followActive == true)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(transform.position, target.transform.position) >= maxrange)
        {
            GoStartingPos();
            followActive = false;
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveForce * Time.deltaTime);
    }

    public void GoStartingPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, homeposition, moveForce * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon")
        {
            followActive = true;
        }
    }
}
