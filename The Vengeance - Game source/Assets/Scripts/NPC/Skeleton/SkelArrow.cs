using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelArrow : MonoBehaviour
{
    //GameObjects
    private GameObject target; // player

    //Files
    private PlayerLife playerLife;
    private PlayerController playerController;

    //Floats
    public float arrowLifeTime = 2;

    //Ints
    public int skeletonAttack = 10;

    void Start()
    {
        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");

        Destroy(gameObject, arrowLifeTime);
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

            if (playerController.shield == true && skeletonAttack > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= skeletonAttack - playerController.defensePlayer;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= skeletonAttack;
            }
            Destroy(gameObject);
        }
    }
}
