using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemLife : MonoBehaviour
{
    //Rigidbody
    public Rigidbody2D rb;


    //Animator
    private Animator myAnim;

    //Files
    private PlayerLevel playerLevel;
    private PlayerGold playerGold;

    //GameObjects
    private GameObject player;
    public GameObject GolemLifeBar;
    public GameObject GolemLifeText;

    //Ints
    public int life = 10;
    public int golemMaxlife = 500;

    //Bools
    public bool dead;

    public bool flashActive;
    [SerializeField]
    public float flashLength = 0f;
    [SerializeField]
    public float flashCounter = 0f;
    private SpriteRenderer bossSprite;

    public void Start()
    {
        //Components
        myAnim = GetComponent<Animator>();

        //GameObjects
        player = GameObject.FindGameObjectWithTag("Player");
        //bossObject = GameObject.FindGameObjectWithTag("Boss Slime");

        //Files
        playerLevel = FindObjectOfType<PlayerLevel>(); // to access the Player Level file
        playerGold = FindObjectOfType<PlayerGold>(); // to access the Player Gold

        //Bools
        dead = false;
    }

    public void Update()
    {
        Vector3 boss = new Vector3(transform.position.x, transform.position.y, transform.position.z); // to calculate the distance (golem)
        Vector3 Ppos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); // to calculate the distance (player)
        if (life <= 0) // to destroy the enemy if life is 0
        {
            
            myAnim.SetBool("dead", true); //dead animation

            Destroy(GolemLifeBar);
            Destroy(GolemLifeText);

            if (dead == true)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                life = 1;
                //Destroy(gameObject);
            }
        }
        if (life > golemMaxlife) // to make sure that the enemy doesn't have more life than the max life
        {
            life = golemMaxlife;
        }
        if (Vector3.Distance(boss, Ppos) > 14.2f) // enemy regenrate life once the player is away
        {
            life = golemMaxlife;
        }
    }

    public void Vanish(string message) //gives player exp and gold after the golem is dead
    {
        if (message.Equals("isDead"))
        {
            dead = true;
            playerLevel.exp += 110;
            playerGold.gold += 100;
        }
    }
}
