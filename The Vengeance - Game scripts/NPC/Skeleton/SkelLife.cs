using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkelLife : MonoBehaviour
{
    //Animator
    private Animator myAnim;

    //Files
    private Quest quest;
    private TalkQuest talkQuest;
    private PlayerLevel playerLevel;
    private PlayerGold playerGold;
    private PlayerController playerController;
    private SkeletonController skelController;

    //GameObjects
    private GameObject player;
    //private GameObject bossObject;
    public GameObject SkelLifeBar;
    //public GameObject SkelLifeText;

    //Ints
    public int life = 10;
    public int skelMaxLife = 100;

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
        skelController = gameObject.GetComponent<SkeletonController>(); // to access the maxRange

        //Bools
        dead = false;
    }

    public void Update()
    {
        Vector3 skel = new Vector3(transform.position.x, transform.position.y, transform.position.z); // to calculate the distance
        Vector3 Ppos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); // to calculate the distance
        if (life <= 0) // to destroy the enemy if life is 0
        {
            myAnim.SetBool("dead", true);

            if(dead == true)
            {
                if(talkQuest.accepted == true)
                {
                    quest.skelCount += 1;
                }
                Destroy(gameObject);
            }
        }
        if (life > skelMaxLife) // to make sure that the enemy doesn't have more life than the max life
        {
            life = skelMaxLife;
        }
        if (Vector3.Distance(skel, Ppos) > 14.2f) // enemy regenrate life once the player is away
        {
            life = skelMaxLife;
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

        if (other.tag == "MyWeapon")
        {
            if (playerController.normalAttack)
            {
                life -= playerController.normalPlayerAttack;
                skelController.gotHit = true;
            }
            else if (playerController.strongAttack)
            {
                life -= playerController.strongPlayerAttack;
                skelController.gotHit = true;
            }
        }
    }
    public void Vanish(string message)
    {
        if (message.Equals("isDead"))
        {
            playerLevel.exp += 110;
            playerGold.gold += 100;
            dead = true;
        }
    }
}
