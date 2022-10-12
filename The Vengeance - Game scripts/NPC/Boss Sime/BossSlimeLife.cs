using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeLife : MonoBehaviour
{
    //Files
    private PlayerLevel playerLevel;
    private PlayerGold playerGold;

    //GameObjects
    private GameObject player;
    private GameObject bossObject;
    public GameObject BossSlimeLifeBar;
    public GameObject BossSlimeLifeText;

    //Ints
    public int life = 10;
    public int bossmaxlife = 100;

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
        //GameObjects
        player = GameObject.FindGameObjectWithTag("Player");
        bossObject = GameObject.FindGameObjectWithTag("Boss Slime");

        //Files
        playerLevel = FindObjectOfType<PlayerLevel>(); // to access the Player Level file
        playerGold = FindObjectOfType<PlayerGold>(); // to access the Player Gold

        //Bools
        dead = false;
    }

    public void Update()
    {
        Vector3 boss = new Vector3(transform.position.x, transform.position.y, transform.position.z); // to calculate the distance
        Vector3 Ppos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); // to calculate the distance
        if (life <= 0) // to destroy the enemy if life is 0
        {
            playerLevel.exp += 110;
            playerGold.gold += 100;

            Destroy(gameObject);
            Destroy(BossSlimeLifeBar);
            Destroy(BossSlimeLifeText);
        }
        if (life > bossmaxlife) // to make sure that the enemy doesn't have more life than the max life
        {
            life = bossmaxlife;
        }
        if (Vector3.Distance(boss, Ppos) > 14.2f) // enemy regenrate life once the player is away
        {
            life = bossmaxlife;
        }

        if (flashActive)
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
        }
    }
}
