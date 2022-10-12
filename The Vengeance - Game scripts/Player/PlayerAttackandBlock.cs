using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackandBlock : MonoBehaviour
{
    private Rigidbody2D rb;
    private BossSlimeLife bossSlimeLife;
    private SlimeLife slimelife;

    //private Transform attackBoxTransform;
    //private BoxCollider2D attackBoxCollider;

    private float attackTime = 0.5f;
    private float attackCounter = 0.5f;

    private float strongAttackHoldTime = 3f;

    public bool normalAttack;
    public bool strongAttack;
    public bool shield;

    public int normalPlayerAttack = 10;
    public int strongPlayerAttack = 15;
    public int defensePlayer = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bossSlimeLife = FindObjectOfType<BossSlimeLife>(); // to access the Player Level file
        slimelife = FindObjectOfType<SlimeLife>();
    }

    void FixedUpdate()
    {
        if (normalAttack)
        {
            rb.velocity = Vector2.zero;
            normalAttack = false;
        }
        else if (strongAttack)
        {
            rb.velocity = Vector2.zero;
            strongAttack = false;
        }
        else if (shield)
        {
            rb.velocity = Vector2.zero;
        }


        attackCounter -= Time.fixedDeltaTime;
        if (attackCounter <= 0 && shield == false)
        {
            // Attack
            if (Input.GetMouseButton(0))
            {
                strongAttackHoldTime -= Time.fixedDeltaTime;

            }

            if (!Input.GetMouseButton(0) && strongAttackHoldTime < 3f)
            {
                //Basic Attack
                if (strongAttackHoldTime > 0)
                {
                    attackCounter = attackTime;
                    normalAttack = true;
                    strongAttackHoldTime = 3f;
                }
            }

            //Strong Attack
            if (strongAttackHoldTime <= 0)
            {
                attackCounter = attackTime;
                strongAttack = true;
                strongAttackHoldTime = 3f;
            }
        }

        //Shield
        if (Input.GetKey(KeyCode.Space))
        {
            shield = true;
        }
        else
        {
            shield = false;
        }

    }
}
