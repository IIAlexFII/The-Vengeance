using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemArrow : MonoBehaviour
{
    //GameObjects
    private GameObject target; // player

    //Files
    private PlayerLife playerLife;
    private PlayerController playerController;

    //Floats
    public float bulletlifeTime = 2;

    //Ints
    public int GolemAttackDamage = 15;

    void Start()
    {
        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, bulletlifeTime); // destroy arrow (bullet) after some time
        playerLife = FindObjectOfType<PlayerLife>(); // to access the Player Level file
        playerController = FindObjectOfType<PlayerController>(); // to access the Player Attack and Block file
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.flashActive = true; //activate player flash
            playerController.flashCounter = playerController.flashLength;

            if (playerController.shield == true && GolemAttackDamage > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= GolemAttackDamage - playerController.defensePlayer;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= GolemAttackDamage;
            }
            Destroy(gameObject);
        }
    }
}
