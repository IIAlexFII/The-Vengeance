using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    //Files
    private PlayerLife playerLife;
    private PlayerController playerController;

    //Floats
    public float meleeAttacktCooldownTime = 0.8f;
    private float meleeAttackTimer = 0;

    //Ints
    public int meleeSlimeAttack = 5;

    void Start()
    {
        //Files
        playerLife = FindObjectOfType<PlayerLife>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (meleeAttackTimer >= 0)
        {
            meleeAttackTimer -= Time.deltaTime;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && meleeAttackTimer <= 0)
        {
            if (playerController.shield == true && meleeSlimeAttack > playerController.defensePlayer) //if player is blocking but the attack value is bigger than the defense value
            {
                playerLife.life -= meleeSlimeAttack - playerController.defensePlayer;

                playerController.flashActive = true;
                playerController.flashCounter = playerController.flashLength;
            }
            else if (playerController.shield == false) //if player isn't blocking
            {
                playerLife.life -= meleeSlimeAttack;
            }
            meleeAttackTimer = meleeAttacktCooldownTime;
        }
    }
}
