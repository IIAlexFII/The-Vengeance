using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPCMovement : MonoBehaviour
{
    private GameObject target; // player
    private Animator myAnim;
    private Rigidbody2D rb;
    private RangedArea rangedArea;

    [SerializeField] private float moveForce = 1f;
    private Vector3[] positionArray;
    private int pointsIndex;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        myAnim = GetComponent<Animator>();

        rangedArea = FindObjectOfType<RangedArea>();
        rb = GetComponent<Rigidbody2D>();
        positionArray = new[] {new Vector3(-297f, - 92.64f), new Vector3(-297f, -102.46f), new Vector3(-261.58f, -102.46f), new Vector3(-261.58f, -80.46f), new Vector3(-261.58f, -102.46f), new Vector3(-297f, -102.46f) };

        pointsIndex = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (rangedArea.playerInRange == false)
        {
            myAnim.SetBool("isMoving", true);
            myAnim.SetFloat("moveX", (positionArray[pointsIndex].x - transform.position.x));
            myAnim.SetFloat("moveY", (positionArray[pointsIndex].y - transform.position.y));

            transform.position = Vector3.MoveTowards(transform.position, positionArray[pointsIndex], moveForce * Time.deltaTime);

            if (transform.position == (positionArray[pointsIndex]))
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
        else
        { //animations
            myAnim.SetFloat("moveX", (target.transform.position.x - transform.position.x));
            myAnim.SetFloat("moveY", (target.transform.position.y - transform.position.y));
            myAnim.SetBool("isMoving", false);
        }
    }
}

