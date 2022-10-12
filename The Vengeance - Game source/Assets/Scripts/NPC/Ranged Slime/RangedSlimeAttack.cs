using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlimeAttack : MonoBehaviour
{

    private GameObject target;
    public GameObject bulletPrefab;
    private RangedSlimeMovement rangedSlimeMovement;
    public float bulletOffset = 2.4f;
    public float bulletSpeed = 5f;
    public float bulletCooldownTime = 7f;
    private float bulletShootTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rangedSlimeMovement = FindObjectOfType<RangedSlimeMovement>(); // to access the Player Level file
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector3.Distance(transform.position, target.transform.position) <= rangedSlimeMovement.maxrange) && (bulletShootTimer <= 0))
        {
            if(rangedSlimeMovement)
            {
                Vector3 playerDirection = target.transform.position - transform.position; // new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
                GameObject bullet = Instantiate(bulletPrefab, transform.position + (playerDirection.normalized * bulletOffset), Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = playerDirection.normalized * bulletSpeed;
                bulletShootTimer = bulletCooldownTime;
            }
        }
        if (bulletShootTimer >= 0)
        {
            bulletShootTimer -= Time.deltaTime;
        }
    }
}
