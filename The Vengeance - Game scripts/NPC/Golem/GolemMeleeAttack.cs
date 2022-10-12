using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemMeleeAttack : MonoBehaviour
{
    //Files
    private PlayerLife playerLife;
    private PlayerController playerController;

    //Ints
    public int GolemMeleeDamage = 10;

    void Start()
    {
        //Files
        playerLife = FindObjectOfType<PlayerLife>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerController.shield == true && GolemMeleeDamage > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= GolemMeleeDamage - playerController.defensePlayer;

                playerController.flashActive = true; //player flashes when he takes damage
                playerController.flashCounter = playerController.flashLength;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= GolemMeleeDamage;
            }
        }
    }
}
