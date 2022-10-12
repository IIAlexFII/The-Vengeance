using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelAttack : MonoBehaviour
{
    //GameObjects
    public GameObject bulletPrefab;
    private GameObject target;

    //Floats
    public float bulletOffset = 2.4f;
    public float bulletSpeed = 15;

    public float bulletCooldownTime = 0.8f;
    private float bulletShootTimer = 0;

    //Bool
    private bool arrowReady = false;

    void Start()
    {
        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (arrowReady)
        {
            Vector3 playerDirection = target.transform.position - transform.position;

            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg + 180;

            GameObject bullet = Instantiate(bulletPrefab, transform.position + (playerDirection.normalized * bulletOffset), Quaternion.Euler(0, 0, angle));

            bullet.GetComponent<Rigidbody2D>().velocity = playerDirection.normalized * bulletSpeed;
            bulletShootTimer = bulletCooldownTime;

            arrowReady = false;
        }
    }

    public void animFireArrow(string message)
    {
        if (message.Equals("ArrowReady"))
        {
            arrowReady = true;
        }
    }
}
