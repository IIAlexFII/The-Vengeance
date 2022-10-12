using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;

    //Sound
    public AudioSource[] sounds;
    public AudioSource soundSword;
    public AudioSource hurt;
    public AudioSource walkSound;

    private OpenUpgrades openUpgrades;
    private TalkQuest talkQuest;
    private TalkBossQuest talkBossQuest;

    public GameObject strongAttackSparkle;
    Animator strongAttackAnim;

    public bool flashActive;
    [SerializeField]
    public float flashLength = 0f;
    [SerializeField]
    public float flashCounter = 0f;
    private SpriteRenderer playerSprite;

    //private Transform attackBoxTransform;
    //private BoxCollider2D attackBoxCollider;

    [SerializeField]
    private float speed = 0f;

    private float attackAnimTime = 0.25f;
    private float attackAnimCounter = 0.25f;

    private float attackTime = 0.5f;
    private float attackCounter = 0.5f;

    private float strongAttackHoldTime = 2f;

    public bool normalAttack;
    public bool strongAttack;
    public bool shield;

    public int normalPlayerAttack = 50;
    public int strongPlayerAttack = 15;
    public int defensePlayer = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        sounds = GetComponents<AudioSource>();
        soundSword = sounds[0];
        hurt = sounds[1];
        walkSound = sounds[2];

        strongAttackAnim = strongAttackSparkle.GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();

        openUpgrades = FindObjectOfType<OpenUpgrades>();

        talkQuest = FindObjectOfType<TalkQuest>();
        talkBossQuest = FindObjectOfType<TalkBossQuest>();
    }

    private void Update()
    {
        if (flashActive)
        {
            hurt.Play();
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (openUpgrades.panelActive == false && talkQuest.playerMove == true && talkBossQuest.playerMove == true)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            rb.velocity = new Vector2(horizontalInput, verticalInput).normalized * speed * Time.fixedDeltaTime;

            anim.SetFloat("moveX", rb.velocity.x);
            anim.SetFloat("moveY", rb.velocity.y);

            if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                anim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }

            if (normalAttack)
            {
                rb.velocity = Vector2.zero;
                attackAnimCounter -= Time.fixedDeltaTime;
                if(attackAnimCounter <= 0)
                {
                    anim.SetBool("isAttacking", false);
                    normalAttack = false;
                }
            }
            else if (strongAttack)
            {
                rb.velocity = Vector2.zero;
                attackAnimCounter -= Time.fixedDeltaTime;
                if (attackAnimCounter <= 0)
                {
                    anim.SetBool("isAttacking", false);
                    strongAttackAnim.SetBool("strongAttackReady", false);
                    strongAttack = false;
                }
            }
            else if (shield)
            {
                rb.velocity = Vector2.zero;
            }

            attackCounter -= Time.fixedDeltaTime;
            if (attackCounter <= 0 && shield == false)
            {
                // Attack
                if (Input.GetMouseButton(0))
                {
                    strongAttackHoldTime -= Time.fixedDeltaTime;
                    if (strongAttackHoldTime <= 0)
                    {
                        strongAttackAnim.SetBool("strongAttackReady", true);
                    }
                }
                if (!Input.GetMouseButton(0) && strongAttackHoldTime < 2f)
                {
                    //Basic Attack
                    if (strongAttackHoldTime > 0)
                    {
                        attackAnimCounter = attackAnimTime;
                        attackCounter = attackTime;
                        anim.SetBool("isAttacking", true);
                        normalAttack = true;
                        strongAttackHoldTime = 2f;
                    }
                    //Strong Attack
                    else if (strongAttackHoldTime <= 0)
                    {
                        attackAnimCounter = attackAnimTime;
                        attackCounter = attackTime;
                        anim.SetBool("isAttacking", true);
                        strongAttack = true;
                        strongAttackHoldTime = 2f;
                    }
                }
            }

            //Shield
            if (Input.GetKey(KeyCode.Space))
            {
                shield = true;
                anim.SetBool("shieldOn", true);
            }
            else
            {
                shield = false;
                anim.SetBool("shieldOn", false);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isAttacking", false);
            strongAttackAnim.SetBool("strongAttackReady", false);
            anim.SetBool("shieldOn", false);
            anim.SetBool("isMoving", false);
            anim.SetFloat("moveX", 0);
            anim.SetFloat("moveY", 0);

        }
        //print("strongAttackHoldTime: " + strongAttackHoldTime);
    }

    public void swordSound(string message)
    {
        if (message.Equals("swordSound"))
        {
            soundSword.Play();
        }
    }

    public void soundWalk(string message)
    {
        if (message.Equals("walkSound"))
        {
            walkSound.Play();
        }
    }

    
}
