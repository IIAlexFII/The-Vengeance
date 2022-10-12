using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    //Int
    public int exp;
    public int maxlevel = 5;
    public int currentmaxexp;
    public int Level = 1;
    [HideInInspector] public int arrayPoints;

    //Arrays
    public int[] maxexp; //stores the max exp needed to level up
    public int[] normalattackpower; //stores the increase of the normal attack power 
    public int[] strongattackpower; //stores the increase of the strong attack power 
    public int[] defensepower; //stores the increase of the defense power 

    //GameObject
    private GameObject BossSlime;

    //Bool
    public bool BossSlimeKilled;
    
    //Files
    private BossSlimeLife bossslimeLife;
    private PlayerLife playerLife;
    private PlayerController playerController;


    void Start()
    {
        //Ints
        currentmaxexp = 100;
        exp = 0;
        arrayPoints = 0;

        //Arrays
        maxexp = new int[] {100, 200, 300, 400, 500};
        normalattackpower = new int[] {10, 15, 20, 25, 30};
        strongattackpower = new int[] {15, 20, 25, 30, 35};
        defensepower = new int[] {5, 10, 15, 20, 25};

        //GameObjects
        BossSlime = GameObject.FindGameObjectWithTag("Boss Slime");

        //Bool
        BossSlimeKilled = false;

        //Files
        bossslimeLife = FindObjectOfType<BossSlimeLife>();
        playerLife = FindObjectOfType<PlayerLife>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        //Debug.Log("Attack: " + playerController.normalPlayerAttack);
        //Debug.Log("Strong Attack: " + playerController.strongPlayerAttack);
        //Debug.Log("Defense: " + playerController.defensePlayer);
        if (exp >= maxexp[arrayPoints])
        {
            arrayPoints++;
            exp = 0;
            playerLife.maxlife += 100;
            Level += 1;
            playerController.normalPlayerAttack = normalattackpower[arrayPoints + 1];
            playerController.strongPlayerAttack = strongattackpower[arrayPoints + 1];
            playerController.defensePlayer = defensepower[arrayPoints + 1];
        }
    }
}
