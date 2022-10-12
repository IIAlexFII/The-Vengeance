using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLife : MonoBehaviour
{
    public GameObject SlimeLifeBar;

    private PlayerLevel playerLevel;
    private PlayerGold playerGold;
    private GameObject player;
    private GameObject meleeSlime;

    public int slimelife = 10;
    public int slimemaxlife = 100;
    [HideInInspector] public bool dead;
    [HideInInspector] public bool onAttack;
    public bool flashActive;
    [SerializeField]
    public float flashLength = 0f;
    [SerializeField]
    public float flashCounter = 0f;
    private SpriteRenderer slimeSprite;

    // Start is called before the first frame update
    void Start()
    {
        meleeSlime = GameObject.FindGameObjectWithTag("Melee Slime");
        player = GameObject.FindGameObjectWithTag("Player");
        playerLevel = FindObjectOfType<PlayerLevel>(); // to access the Player Level file
        playerGold = FindObjectOfType<PlayerGold>(); // to access the Player Gold
        slimeSprite = GetComponent<SpriteRenderer>();
        dead = false;
        onAttack = false;
    }

    // Update is called once per frame
    public void Update()
    {
        Vector3 slimepos = new Vector3(transform.position.x, transform.position.y, transform.position.z); // to calculate the distance
        Vector3 Ppos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z); // to calculate the distance
        if (slimelife < 0) // to make sure that the enemy doesn't have the life under 0
        {
            slimelife = 0;
        }
        if (slimelife == 0) // to destroy the enemy if life is 0
        {
            dead = true;

            if (dead == true)
            {
                playerGold.gold += 25;
                playerLevel.exp += 30;
                dead = false;
                Destroy(SlimeLifeBar);
                Destroy(gameObject);
                Debug.Log(dead);
            }
        }
        if (slimelife > slimemaxlife) // to make sure that the enemy doesn't have more life than the max life
        {
            slimelife = slimemaxlife;
        }
        if (Vector3.Distance(slimepos, Ppos) > 14.2f) // enemy regenrate life once the player is away
        {
            slimelife = slimemaxlife;
        }

        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 0f);
            }
            else
            {
                slimeSprite.color = new Color(slimeSprite.color.r, slimeSprite.color.g, slimeSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
}

