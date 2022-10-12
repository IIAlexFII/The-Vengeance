using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonoBehaviour
{
    //GameObjects
    private GameObject target; // player
    private OpenUpgrades openUpgrades;
    public GameObject goToUpgrades; // go to upgrades info

    //Sound
    public AudioSource[] sounds;
    public AudioSource soundSword;
    public AudioSource soundDead;

    //Animation
    private Animator myAnim;
    private bool AnimOn = false;

    private float waitNextAttackTimer = 0f;
    public bool nextAttackReady = true;

    //Floats
    public float moveForce = 2;
    public float moving = 2;
    public float stopped = 0;
    public float maxrange = 9;
    public float minrange = 4f;
    private float gotHitTimer = 0f;

    //Ints
    private int pointsIndex;

    //Bools
    public bool following = false;
    public bool gotHit = false;
    public bool patrol = false;

    //Arrays
    private Vector3[] positionArray; //array initiation

    void Start()
    {
        //Files
        openUpgrades = FindObjectOfType<OpenUpgrades>();

        //GameObjects
        target = GameObject.FindGameObjectWithTag("Player");
        goToUpgrades = GameObject.FindGameObjectWithTag("Open Upgrades");

        //Components
        myAnim = GetComponent<Animator>();

        sounds = GetComponents<AudioSource>();
        soundSword = sounds[0];
        soundDead = sounds[1];

        //Arrays
        if (patrol == true) //put values in the array
        {
            positionArray = new[] { new Vector3(transform.position.x , transform.position.y), new Vector3(transform.position.x + 10, transform.position.y) };
        }
        else
        {
            positionArray = new[] { new Vector3(transform.position.x, transform.position.y), new Vector3(transform.position.x, transform.position.y + 10) };
        }
        

        //Variables
        pointsIndex = 0;
    }

    void Update()
    {
        if (nextAttackReady == false) //see if attack is ready
        {
            waitNextAttackTimer += Time.deltaTime;
            if (waitNextAttackTimer >= 2)
            {
                nextAttackReady = true;
            }
        }
        gotHitTimer += Time.deltaTime;

        //Follow Player
        if (Vector3.Distance(transform.position, target.transform.position) <= maxrange && Vector3.Distance(transform.position, target.transform.position) > minrange && AnimOn == false)
        {
            FollowPlayer();
            openUpgrades.enabled = false;
            goToUpgrades.gameObject.SetActive(false);
            following = true;
        }

        //Melee Attack
        else if (Vector3.Distance(transform.position, target.transform.position) <= minrange && AnimOn == false)
        {
            MeleeAttackAnim();
            if (nextAttackReady == false)
            {
                if(gotHit == true)
                {
                    GotHit();
                }
                else
                {
                    FollowPlayer();
                }
            }
        }

        //Go Staring Position
        else if (Vector3.Distance(transform.position, target.transform.position) > maxrange && AnimOn == false)
        {
            GoStartingPos();
            openUpgrades.enabled = true;
            if (goToUpgrades.gameObject.activeSelf == false)
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
        myAnim.SetBool("isAttacking", false);
        myAnim.SetBool("hit", false);
        myAnim.SetFloat("moveX", (target.transform.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.transform.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveForce * Time.deltaTime); //move towards player
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) //for the animations
        {
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal") * -1);
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical") * -1);
        }
    }

    public void MeleeAttackAnim() //play animations
    {
        if (nextAttackReady)
        {
            myAnim.SetFloat("lastMoveX", (target.transform.position.x - transform.position.x));
            myAnim.SetFloat("lastMoveY", (target.transform.position.y - transform.position.y));

            AnimOn = true;
            moveForce = stopped;
            myAnim.SetBool("isMoving", false);
            myAnim.SetBool("hit", false);
            myAnim.SetBool("isAttacking", true);
        }
    }

    public void GotHit() //play animations
    {
        if (gotHitTimer >= 4)
        {
            AnimOn = true;
            moveForce = stopped;
            myAnim.SetBool("isMoving", false);
            myAnim.SetBool("hit", true);
            myAnim.SetBool("isAttacking", false);
            gotHitTimer = 0;
        } 
    }

    public void animEnd(string message) //end of animation
    {
        if (message.Equals("AnimationEnded"))
        {
            waitNextAttackTimer = 0;
            AnimOn = false;
            nextAttackReady = false;
            gotHit = false;
            myAnim.SetBool("isAttacking", false);
            myAnim.SetBool("isMoving", false);
            myAnim.SetBool("hit", false);
        }
    }

    public void GoStartingPos() //walk
    {
        moveForce = moving;
        myAnim.SetBool("isMoving", true);
        myAnim.SetBool("hit", false);
        myAnim.SetBool("isAttacking", false);
        myAnim.SetFloat("moveX", (positionArray[pointsIndex].x - transform.position.x));
        myAnim.SetFloat("moveY", (positionArray[pointsIndex].y - transform.position.y));

        transform.position = Vector3.MoveTowards(transform.position, positionArray[pointsIndex], moveForce * Time.deltaTime);

        if (transform.position == positionArray[pointsIndex]) //array called here
        {
            //Next point of the array of Locations
            pointsIndex++;
        }

        if (pointsIndex == (positionArray.Length)) //array called here
        {
            //Going Back to the start point
            pointsIndex = 0;
        }
    }

    public void swordSound(string message)
    {
        if (message.Equals("swordSound"))
        {
            soundSword.Play();
        }
    }

    public void deadSound(string message)
    {
        if (message.Equals("dead"))
        {
            soundDead.Play();
        }
    }
}
