using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    private PlayerController playerController;
    private GolemLife golemLife;
    private GolemController golemController;

    private OrcLife orcLife;
    private OrcController orcController;

    private SkelLife skelLife;
    private SkeletonController skelController;

    int life = 100;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        golemLife = FindObjectOfType<GolemLife>();

        orcLife = FindObjectOfType<OrcLife>();
        orcController = FindObjectOfType<OrcController>();

        skelLife = FindObjectOfType<SkelLife>();
        skelController = FindObjectOfType<SkeletonController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Golem")
        {
            golemLife.flashActive = true;
            golemLife.flashCounter = golemLife.flashLength;

            if (playerController.normalAttack)
            {
                golemLife.life -= playerController.normalPlayerAttack;
            }
            else if (playerController.strongAttack)
            {
                golemLife.life -= playerController.strongPlayerAttack;
            }
        }

        /*if (other.tag == "Skeleton")
        {
            if (playerController.normalAttack)
            {
                skelLife.life -= playerController.normalPlayerAttack;
                skelController.gotHit = true;
            }
            else if (playerController.strongAttack)
            {
                skelLife.life -= playerController.strongPlayerAttack;
                skelController.gotHit = true;
            }
        }*/

        /*if (other.tag == "Orc")
        {

            if (playerController.normalAttack)
            {
                print("playerController.normalPlayerAttack: " + playerController.normalPlayerAttack);
                orcLife.life -= playerController.normalPlayerAttack;
                life -= playerController.normalPlayerAttack;
                orcController.gotHit = true;
            }
            else if (playerController.strongAttack)
            {
                orcLife.life -= playerController.strongPlayerAttack;
                orcController.gotHit = true;
            }
        }*/
    }
}
