using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedSlimeBullet : MonoBehaviour
{
    public float bulletlifeTime = 2;
    private PlayerLife playerLife;
    private PlayerController playerController;

    public int rangedSlimeAttack = 5;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, bulletlifeTime);
        playerLife = FindObjectOfType<PlayerLife>(); // to access the Player Level file
        playerController = FindObjectOfType<PlayerController>(); // to access the Player Attack and Block file
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.flashActive = true;
            playerController.flashCounter = playerController.flashLength;

            Destroy(gameObject);
            if (playerController.shield == true && rangedSlimeAttack > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= rangedSlimeAttack - playerController.defensePlayer;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= rangedSlimeAttack;
            }
        }
    }
}
