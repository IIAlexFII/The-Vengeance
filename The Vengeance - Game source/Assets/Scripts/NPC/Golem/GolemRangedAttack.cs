using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemRangedAttack : MonoBehaviour
{
    //Transform
    public Transform target;

    //GameObjects
    public GameObject bulletPrefab;

    //Files
    private GolemController golemController;

    //Floats
    public float bulletOffset = 2.4f;
    public float bulletSpeed = 15;

    public float bulletCooldownTime = 0.8f;
    private float bulletShootTimer = 0;

    //Bool
    private bool arrowReady = true;

    void Start()
    {
        //Files
        golemController = FindObjectOfType<GolemController>();
    }

    void Update()
    {
        if (arrowReady)
        {
            Vector3 playerDirection = target.transform.position - transform.position; //get the direction of the player

            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg + 180; //so that the arraow rotates

            GameObject bullet = Instantiate(bulletPrefab, transform.position + (playerDirection.normalized * bulletOffset), Quaternion.Euler(0, 0, angle)); //instatiate bullet

            bullet.GetComponent<Rigidbody2D>().velocity = playerDirection.normalized * bulletSpeed; //give bullet velocity
            bulletShootTimer = bulletCooldownTime;

            arrowReady = false;
        }
    }

    public void animFireArrow(string message) //animation
    {
        if (message.Equals("ArrowReady"))
        {
            arrowReady = true;
        }
    }
}
