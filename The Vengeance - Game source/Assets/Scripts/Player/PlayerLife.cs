using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //Int
    public int life = 100;
    public int maxlife = 100;
    public int timer = 0;
    public int regenerationtimer = 1500;

    //GameObject
    private GameObject enemy;

    //File
    private PlayerLevel playerLevel;

    public void Start()
    {
        //GameObject
        enemy = GameObject.FindGameObjectWithTag("Boss Slime");

        //Files
        playerLevel = FindObjectOfType<PlayerLevel>(); // to access the Player Level file
    }

    public void Update()
    {
        if (life <= 0) // to destroy the player if life is 0 | missing changing to game over menu
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(gameObject);
        }
        if (life != maxlife && life < maxlife) // regenerat life if life is differnt and smaller than maxlife
        {
            timer = timer + 1;
            if (timer == regenerationtimer)
            {
                life = life + 5; // add 5 to life
                if(life > maxlife) // to make sure that the enemy doesn't have more life than the max life
                {
                    life = maxlife;
                }
                timer = 0; // restart timer
            }
        }
    }
}
