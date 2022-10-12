using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeRangedAttack : MonoBehaviour
{
    //Transform
    public Transform target;

    //GameObjects
    public GameObject bulletPrefab;

    //Files
    private BossSlimeMovement bossslimeMovement;

    //Floats
    public float bulletOffset = 2.4f;
    public float bulletSpeed = 15;
    
    public float bulletCooldownTime = 0.8f;
    private float bulletShootTimer = 0;

    //Bool
    private bool arrowReady = true;

    void Start()
    {
        //GameObjects
        //target = GameObject.FindGameObjectWithTag("Player");

        //Files
        bossslimeMovement = FindObjectOfType<BossSlimeMovement>();
    }

    void Update()
    {
        if (arrowReady)//bossslimeMovement.nextAttackReady && (bulletShootTimer <= 0)
        {
            Vector3 playerDirection = target.transform.position - transform.position;

            float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg + 180;

            GameObject bullet = Instantiate(bulletPrefab, transform.position + (playerDirection.normalized * bulletOffset), Quaternion.Euler(0, 0, angle));

            bullet.GetComponent<Rigidbody2D>().velocity = playerDirection.normalized * bulletSpeed;
            bulletShootTimer = bulletCooldownTime;

            arrowReady = false;
        }

        /*if (bulletShootTimer >= 0)
        {
            bulletShootTimer -= Time.deltaTime;
        }*/
    }

    public void animFireArrow(string message)
    {
        if (message.Equals("ArrowReady"))
        {
            arrowReady = true;
        }
    }

}
