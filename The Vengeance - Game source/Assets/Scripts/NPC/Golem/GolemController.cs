using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemController : MonoBehaviour
{

    private AreaTransitions areaTransitions;

    //GameObjects
    private GameObject target; // player
    private OpenUpgrades openUpgrades;
    public GameObject goToUpgrades; // go to upgrades info

    //Sound
    public AudioSource[] sounds;
    public AudioSource attackSound;
    public AudioSource soundArrow;
    public AudioSource soundWalk;

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
        areaTransitions = FindObjectOfType<AreaTransitions>();

        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");
        goToUpgrades = GameObject.FindGameObjectWithTag("Open Upgrades");

        //Components
        myAnim = GetComponent<Animator>();

        //Arrays
        positionArray = new[] { new Vector3(-194.64f, -98.17f), new Vector3(-194.64f, -107.18f), new Vector3(-175.19f, -107.18f), new Vector3(-175.19f, -98.17f) };

        //Variables
        pointsIndex = 0;

        sounds = GetComponents<AudioSource>();
        soundArrow = sounds[0];
        attackSound = sounds[1];
        soundWalk = sounds[2];
    }

    void Update()
    {

        if (nextAttackReady == false)//to know when the golem will do an attack
        {
            waitNextAttackTimer += Time.deltaTime; //add time to waitNextAttackTimer
            if (waitNextAttackTimer >= 2)
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

            if (nextAttackReady == false)
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
            if(goToUpgrades.gameObject.activeSelf == false)
            {
                goToUpgrades.gameObject.SetActive(true);
            }
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
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveForce * Time.deltaTime); //move towards player
    }

    public void MeleeAttackPlayerAnim() //melee attack animation
    {
        if (nextAttackReady)
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

    public void RangedAttackPlayerAnim() //ranged attack animation
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

    public void animEnd(string message) //end of the animation
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

    public void arrowSound(string message)
    {
        if (message.Equals("arrowSound"))
        {
            soundArrow.Play();
            
        }
    }

    public void soundAttack(string message)
    {
        if (message.Equals("attackSound"))
        {
            attackSound.Play();
        }
    }

    public void WalkSound(string message)
    {
        if (message.Equals("walk") && (areaTransitions.golemHealthBarOn == true))
        {
            soundWalk.Play();
        }
    }

    public void GoStartingPos() //go to the next position in the array or go back to the first position in the array
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
