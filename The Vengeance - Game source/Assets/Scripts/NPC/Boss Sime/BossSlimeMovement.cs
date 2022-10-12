using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeMovement : MonoBehaviour
{
    //GameObjects
    private GameObject target; // player
    private OpenUpgrades openUpgrades;
    public GameObject goToUpgrades; // go to upgrades info

    //Animation
    private Animator myAnim;
    private bool AnimOn = false;

    private float waitNextAttackTimer = 0f;
    public bool nextAttackReady = true;

    //Floats
    public float moveForce = 2;
    public float moving = 2;
    public float stopped = 0;
    public float maxrange = 20;
    public float midrange = 8;
    public float minrange = 4f;

    //Ints
    private int pointsIndex;

    //Bools
    public bool following = false;

    //Arrays
    private Vector3[] positionArray;

    void Start()
    {
        //Files
        openUpgrades = FindObjectOfType<OpenUpgrades>();

        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");
        goToUpgrades = GameObject.FindGameObjectWithTag("Open Upgrades");

        //Components
        myAnim = GetComponent<Animator>();

        //Arrays
        positionArray = new[] { new Vector3(-185.07f, -96.78f), new Vector3(-185.07f, -107.8f), new Vector3(-165.52f, -107.8f), new Vector3(-165.52f, -96.78f) };

        //Variables
        pointsIndex = 0;
    }

    void Update()
    {
        if(nextAttackReady == false)
        {
            waitNextAttackTimer += Time.deltaTime;
            if(waitNextAttackTimer >= 2)
            {
                nextAttackReady = true;
            }
        }
        //Follow Player
        if (Vector3.Distance(transform.position, target.transform.position) <= midrange && Vector3.Distance(transform.position, target.transform.position) > minrange && AnimOn == false)
        {
            FollowPlayer();
            openUpgrades.enabled = false;
            goToUpgrades.gameObject.SetActive(false);
            following = true;
        }
        //Ranged Attack
        else if (Vector3.Distance(transform.position, target.transform.position) <= maxrange && Vector3.Distance(transform.position, target.transform.position) > midrange && AnimOn == false)
        {
            RangedAttackPlayerAnim();

            if(nextAttackReady == false)
            {
                FollowPlayer();
            }
            
        }
        //Melee Attack
        else if (Vector3.Distance(transform.position, target.transform.position) <= minrange && AnimOn == false)
        {
            MeleeAttackPlayerAnim();
        }
        //Go Staring Position
        else if (Vector3.Distance(transform.position, target.transform.position) >= maxrange && AnimOn == false)
        {
            GoStartingPos();
            openUpgrades.enabled = true;
            goToUpgrades.gameObject.SetActive(true);
            following = false;
        }
    }

    public void FollowPlayer()
    {
        moveForce = moving;
        myAnim.SetBool("isMoving", true);
        myAnim.SetBool("isMeleeAttacking", false);
        myAnim.SetBool("isRangedAttacking", false);
        myAnim.SetFloat("moveX", (target.transform.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.transform.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveForce * Time.deltaTime);
    }

    public void MeleeAttackPlayerAnim()
    {
        if(nextAttackReady)
        {
            myAnim.SetFloat("lastMoveX", (target.transform.position.x - transform.position.x));
            myAnim.SetFloat("lastMoveY", (target.transform.position.y - transform.position.y));
            AnimOn = true;
            moveForce = stopped;
            myAnim.SetBool("isMoving", false);
            myAnim.SetBool("isRangedAttacking", false);
            myAnim.SetBool("isMeleeAttacking", true);
        }
    }

    public void RangedAttackPlayerAnim()
    {
        if (nextAttackReady)
        {
            myAnim.SetFloat("lastMoveX", (target.transform.position.x - transform.position.x));
            myAnim.SetFloat("lastMoveY", (target.transform.position.y - transform.position.y));
            AnimOn = true;
            moveForce = stopped;
            myAnim.SetBool("isMoving", false);
            myAnim.SetBool("isMeleeAttacking", false);
            myAnim.SetBool("isRangedAttacking", true);
            
        }
    }

    public void animEnd(string message)
    {
        if (message.Equals("AnimationEnded"))
        {
            waitNextAttackTimer = 0;
            AnimOn = false;
            nextAttackReady = false;
            myAnim.SetBool("isMeleeAttacking", false);
            myAnim.SetBool("isRangedAttacking", false);
        }
    }

    public void GoStartingPos()
    {
        moveForce = moving;
        myAnim.SetBool("isMoving", true);
        myAnim.SetBool("isMeleeAttacking", false);
        myAnim.SetBool("isRangedAttacking", false);
        myAnim.SetFloat("moveX", (positionArray[pointsIndex].x - transform.position.x));
        myAnim.SetFloat("moveY", (positionArray[pointsIndex].y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, positionArray[pointsIndex], moveForce * Time.deltaTime);

        if (transform.position == positionArray[pointsIndex])
        {
            //Next point of the array of Locations
            pointsIndex++;
        }

        if (pointsIndex == (positionArray.Length))
        {
            //Going Back to the start point
            pointsIndex = 0;
        }
    }
}
