using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    //GameObjects
    private GameObject target; // player
    private OpenUpgrades openUpgrades;
    public GameObject goToUpgrades; // go to upgrades info

    //Animator
    private Animator myAnim;

    //Floats
    public float range = 10f;
    private float waitNextAttackTimer = 0f;
    private float gotHitTimer = 0f;

    //Bools
    public bool nextAttackReady = false;
    private bool AnimOn = false;
    public bool gotHit = false;

    //Sound
    private AudioSource soundArrow;
    void Start()
    {
        //Files
        openUpgrades = FindObjectOfType<OpenUpgrades>();

        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");
        goToUpgrades = GameObject.FindGameObjectWithTag("Open Upgrades");

        //Components
        myAnim = GetComponent<Animator>();

        soundArrow = gameObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (nextAttackReady == false)
        {
            waitNextAttackTimer += Time.deltaTime;
            if (waitNextAttackTimer >= 2)
            {
                nextAttackReady = true;
            }
        }

        gotHitTimer += Time.deltaTime;

        if (gotHit == true && AnimOn == false)
        {
            GotHit();
        }

        //Ranged Attack
        if (Vector3.Distance(transform.position, target.transform.position) <= range && AnimOn == false)
        {
            if (nextAttackReady)
            {
                AttackAnim();
            }
        }
    }

    public void AttackAnim()
    {
        myAnim.SetFloat("lastMoveX", (target.transform.position.x - transform.position.x));
        myAnim.SetFloat("lastMoveY", (target.transform.position.y - transform.position.y));
        openUpgrades.enabled = false;
        
        //goToUpgrades.gameObject.SetActive(false);
        AnimOn = true;
        myAnim.SetBool("isAttacking", true);
        myAnim.SetBool("hit", false);
    }

    public void GotHit()
    {
        if(gotHitTimer >= 2.5)
        {
            myAnim.SetFloat("lastMoveX", (target.transform.position.x - transform.position.x));
            myAnim.SetFloat("lastMoveY", (target.transform.position.y - transform.position.y));
            AnimOn = true;
            myAnim.SetBool("hit", true);
            myAnim.SetBool("isAttacking", false);
            gotHitTimer = 0;
        }
    }

    public void animEnd(string message)
    {
        if (message.Equals("AnimationEnded"))
        {
            waitNextAttackTimer = 0;
            AnimOn = false;
            nextAttackReady = false;
            gotHit = false;
            myAnim.SetBool("isAttacking", false);
            myAnim.SetBool("hit", false);
        }
    }

    public void arrowSound(string message)
    {
        if (message.Equals("arrowSound"))
        {
            soundArrow.Play();
        }
    }
}
