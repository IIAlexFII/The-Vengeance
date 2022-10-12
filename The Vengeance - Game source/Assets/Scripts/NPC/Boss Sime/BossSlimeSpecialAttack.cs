using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeSpecialAttack : MonoBehaviour
{
    //Game Objects
    public GameObject normalSlimePrefab;

    public GameObject rangedSlimePrefab;

    //Files
    private BossSlimeLife bossSlimeLife;
    private BossSlimeMovement bossSlimeMovement;
    private BossSlimeMeleeAttack meleeAttack;
    private BossSlimeRangedAttack rangedAttack;
    private BossSlimeLifeBar bossLifeBar;

    //Floats
    public float specialAttackCooldownTime = 5f;
    private float SpecialAttackTimer = 5f;

    //Bools
    public bool specialAttackActive = false;

    //Arrays
    private Vector3[] slimesposition;

    void Start()
    {
        //Files
        bossSlimeLife = FindObjectOfType<BossSlimeLife>();
        bossSlimeMovement = FindObjectOfType<BossSlimeMovement>();
        meleeAttack = FindObjectOfType<BossSlimeMeleeAttack>();
        rangedAttack = FindObjectOfType<BossSlimeRangedAttack>();
        bossLifeBar = FindObjectOfType<BossSlimeLifeBar>();

        //Array
        slimesposition = new[] { new Vector3(-2.5f, -2f), new Vector3(2.5f, 4f), new Vector3(-2f, 2f), new Vector3(3f, -2f)};
    }

    void Update()
    {
        SpecialAttack();
    }

    public void SpecialAttack()
    {
        if (bossSlimeMovement.following == true)
        {
            SpecialAttackTimer -= Time.deltaTime;
            if (SpecialAttackTimer <= 0 && specialAttackActive == false)
            {
                //Disable files and change move force of boss slime
                specialAttackActive = true;
                bossSlimeLife.enabled = false;
                bossSlimeMovement.moveForce = 0;
                bossSlimeMovement.enabled = false;
                meleeAttack.enabled = false;
                rangedAttack.enabled = false;
                //bossLifeBar.enabled = false;


                //Instantiate melee and ranged slimes
                GameObject normalslime1 = Instantiate(normalSlimePrefab, transform.position + slimesposition[0], Quaternion.identity);
                GameObject normalslime2 = Instantiate(normalSlimePrefab, transform.position + slimesposition[1], Quaternion.identity);

                //GameObject rangedslime1 = Instantiate(rangedSlimePrefab, transform.position + slimesposition[2], Quaternion.identity);
                //GameObject rangedslime2 = Instantiate(rangedSlimePrefab, transform.position + slimesposition[3], Quaternion.identity);

                if (normalslime1 == null && normalslime2 == null)
                {
                    //Enable files and change move force of boss slime
                    SpecialAttackTimer = specialAttackCooldownTime;
                    bossSlimeLife.enabled = true;
                    meleeAttack.enabled = true;
                    rangedAttack.enabled = true;
                    bossSlimeMovement.enabled = true;
                    bossSlimeMovement.moveForce = 2;
                    specialAttackActive = false;
                    bossLifeBar.enabled = true;
                }
            }
        }
    }
}
