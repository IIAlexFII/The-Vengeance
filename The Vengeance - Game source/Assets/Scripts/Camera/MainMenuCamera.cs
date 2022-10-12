using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private float moveForce = 1f;
    private Vector3[] positionArray;
    private int pointsIndex;
    private Vector3 initialPos = new Vector3(-0.03f, 0.37f, -1f);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = initialPos;

        positionArray = new[] { new Vector3(7.72f, 9.6f, -1f), new Vector3(12.74f, 11.16f, -1f),
                                new Vector3(12.74f, 20.49f, -1f), new Vector3(-2.39f, 20.49f, -1f),
                                new Vector3(-2.39f, -0.28f, -1f), new Vector3(12.96f, -6.38f, -1f), 
                                new Vector3(-6.86f, 2.52f, -1f), new Vector3(-7.65f, -2.54f, -1f), 
                                new Vector3(-13.48f, 1f, -1f),new Vector3(-12.94f, 13.06f, -1f), 
                                new Vector3(-6.48f, 16.83f, -1f)};

        pointsIndex = 0;

    }

    // Update is called once per frame
    void Update()
    {
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
}
