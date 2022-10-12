using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeMeleeAttack : MonoBehaviour
{
    //Files
    private PlayerLife playerLife;
    private PlayerController playerController;

    //Ints
    public int meleeBossSlimeAttack = 10;

    void Start()
    {
        //Files
        playerLife = FindObjectOfType<PlayerLife>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerController.shield == true && meleeBossSlimeAttack > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= meleeBossSlimeAttack - playerController.defensePlayer;

                playerController.flashActive = true;
                playerController.flashCounter = playerController.flashLength;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= meleeBossSlimeAttack;
            }
        }
    }
}
