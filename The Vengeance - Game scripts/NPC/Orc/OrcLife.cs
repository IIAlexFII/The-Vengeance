using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcLife : MonoBehaviour
{
    //Animator
    private Animator myAnim;

    //Files
    private Quest quest;
    private TalkQuest talkQuest;
    private PlayerLevel playerLevel;
    private PlayerGold playerGold;
    private PlayerController playerController;
    private OrcController orcController;
    private GolemSpecialAttack golemSpecialAttack;

    //GameObjects
    private GameObject player;
    //private GameObject bossObject;
    public GameObject OrcLifeBar;
    //public GameObject OrcLifeText;

    //Ints
    public int life = 10;
    public int orcMaxLife = 100;

    //Bools
    public bool dead;

    /*public bool flashActive;
    [SerializeField]
    public float flashLength = 0f;
    [SerializeField]
    public float flashCounter = 0f;
    private SpriteRenderer bossSprite;*/

    public void Start()
    {
        //Components
        myAnim = GetComponent<Animator>();

        //GameObjects
        player = GameObject.FindGameObjectWithTag("Player");

        //bossObject = GameObject.FindGameObjectWithTag("Boss Slime");

        //Files
        quest = FindObjectOfType<Quest>();
        talkQuest = FindObjectOfType<TalkQuest>();
        playerController = FindObjectOfType<PlayerController>();
        playerLevel = FindObjectOfType<PlayerLevel>(); // to access the Player Level file
        playerGold = FindObjectOfType<PlayerGold>(); // to access the Player Gold
        golemSpecialAttack = FindObjectOfType<GolemSpecialAttack>();

        orcController = gameObject.GetComponent<OrcController>(); // to access the maxRange
        

        //Bools
        dead = false;
    }

    public void Update()
    {
        Vector3 orc = new Vector3(transform.position.x, transform.position.y, transform.position.z); // to calculate the distance
        Vector3 Ppos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); // to calculate the distance
        if (life <= 0) // to destroy the enemy if life is 0
        {

            myAnim.SetBool("dead", true); //animation dead

            if (dead == true)
            {
                if (talkQuest.accepted == true)
                {
                    quest.orcCount += 1;
                }
                Destroy(gameObject);
            }
        }
        if (life > orcMaxLife) // to make sure that the enemy doesn't have more life than the max life
        {
            life = orcMaxLife;
        }
        if (Vector3.Distance(orc, Ppos) > orcController.maxrange) // enemy regenrate life once the player is away
        {
           life = orcMaxLife;
        }

        /*if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 0f);
            }
            else
            {
                bossSprite.color = new Color(bossSprite.color.r, bossSprite.color.g, bossSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "MyWeapon") //player attack
        {

            if (playerController.normalAttack)
            {
                life -= playerController.normalPlayerAttack;
                orcController.gotHit = true;
            }
            else if (playerController.strongAttack)
            {
                life -= playerController.strongPlayerAttack;
                orcController.gotHit = true;
            }
        }
    }
    public void Vanish(string message) //give player exp and gold once the orc is dead
    {
        if (message.Equals("isDead"))
        {
            playerLevel.exp += 110;
            playerGold.gold += 100;
            dead = true;
        }
    }
}
