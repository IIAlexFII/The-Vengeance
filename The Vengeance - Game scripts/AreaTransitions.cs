using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTransitions : MonoBehaviour
{

    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    public Vector3 movePlayer;

    public bool golemHealthBarOn = false;
    public GameObject golemHealthBar;

    private AudioSource soundGolemRawr;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();

        soundGolemRawr = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            cam.minPosition = newMinPos;
            cam.maxPosition = newMaxPos;
            other.transform.position += movePlayer;
            if(golemHealthBarOn == true)
            {
                golemHealthBar.SetActive(true);
            }
            else
            {
                golemHealthBar.SetActive(false);
            }
            soundGolemRawr.Play();
        }   
    }
}
