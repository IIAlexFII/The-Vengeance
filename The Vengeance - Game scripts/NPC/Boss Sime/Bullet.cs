using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //GameObjects
    private GameObject target; // player

    //Files
    private PlayerLife playerLife;
    private PlayerController playerController;

    //Floats
    public float bulletlifeTime = 2;
    /*float smooth = 5.0f;
    float tiltAngle = 60.0f;*/

    //public float speed = 1.0f;

    //Ints
    public int rangedBossSlimeAttack = 15;

    void Start()
    {
        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, bulletlifeTime);
        playerLife = FindObjectOfType<PlayerLife>(); // to access the Player Level file
        playerController = FindObjectOfType<PlayerController>(); // to access the Player Attack and Block file
    }

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.flashActive = true;
            playerController.flashCounter = playerController.flashLength;

            if (playerController.shield == true && rangedBossSlimeAttack > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= rangedBossSlimeAttack - playerController.defensePlayer;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= rangedBossSlimeAttack;
            }
            Destroy(gameObject);
        }
    }
}
