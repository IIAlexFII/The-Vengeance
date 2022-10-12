using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class ChangeInfoAttackUpgrades : MonoBehaviour
{
    private PlayerAttackandBlock playerAttackandBlock;
    private PlayerGold playerGold;
    private PlayerLevel playerLevel;
    private OpenUpgrades openUpgrades;
    private InfoUpgrades infoUpgrades;

    public Button attackUpgrade1, attackUpgrade2, attackUpgrade3, attackUpgrade4;
    public Button doUpgrade;

    public GameObject noGoldText; //player has no gold but still trys to do the upgrade
    public GameObject noLevelText; //player has a lower level than what is needed but still trys to do the upgrade
    public GameObject noGoldOrLevelText;
    public GameObject alreadyDidText; //player did this upgrade before but trys to do it again
    public GameObject upgradeDoneText; //player has gold, level and didn't do this upgrade before and does the upgrade

    public float showMessageCoolDownTimer = 5f;
    private float showMessageTimer = 0;

    public Text levelText;
    public Text goldText;
    public Text normalAtkText;
    public Text strongAtkText;

    private Attack attack1;
    private Attack attack2;
    private Attack attack3;
    private Attack attack4;

    public bool doUpgradeIsClicked = false;

    public bool attackBtn1Active = false;
    public bool attackBtn2Active = false;
    public bool attackBtn3Active = false;
    public bool attackBtn4Active = false;

    public bool attackUpgrade1Done = false;
    public bool attackUpgrade2Done = false;
    public bool attackUpgrade3Done = false;
    public bool attackUpgrade4Done = false;


    // Start is called before the first frame update
    void Start()
    {

        playerAttackandBlock = FindObjectOfType<PlayerAttackandBlock>();
        playerGold = FindObjectOfType<PlayerGold>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        openUpgrades = FindObjectOfType<OpenUpgrades>();
        infoUpgrades = new InfoUpgrades();

        noGoldText.gameObject.SetActive(false);
        noLevelText.gameObject.SetActive(false);
        noGoldOrLevelText.gameObject.SetActive(false);
        alreadyDidText.gameObject.SetActive(false);
        upgradeDoneText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        //attackUpgrade1.onClick.AddListener(AttackBtn1Clicked);
        //attackUpgrade2.onClick.AddListener(AttackBtn2Clicked);
        //attackUpgrade3.onClick.AddListener(AttackBtn3Clicked);
        //attackUpgrade4.onClick.AddListener(AttackBtn4Clicked);

        //doUpgrade.onClick.AddListener(DoUpgradeBtnIsClicked);


        if (showMessageTimer <= 0)
        {
            noGoldText.gameObject.SetActive(false);
            noLevelText.gameObject.SetActive(false);
            noGoldOrLevelText.gameObject.SetActive(false);
            alreadyDidText.gameObject.SetActive(false);
            upgradeDoneText.gameObject.SetActive(false);
        }
        else
        {
            showMessageTimer -= Time.deltaTime;
        }
    }

    private void DoUpgradeBtnIsClicked()
    {
        doUpgradeIsClicked = true;
        showMessageTimer = showMessageCoolDownTimer;
    }

    private void AttackBtn1Clicked ()
    {
        //write info about the upgtrade
        levelText.text = "Level: " + attack1.level;
        goldText.text = "Gold: " + attack1.gold;
        normalAtkText.text = "Normal Attack: +" + attack1.natk;
        strongAtkText.text = "Strong Attack: +" + attack1.satk;

        attackBtn1Active = true;

        attackBtn2Active = false;
        attackBtn3Active = false;
        attackBtn4Active = false;

        if (playerGold.gold >= attack1.gold && playerLevel.Level >= attack1.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && attackUpgrade1Done == false)
            {
                playerAttackandBlock.normalPlayerAttack += attack1.natk;
                playerAttackandBlock.strongPlayerAttack += attack1.satk;
                doUpgradeIsClicked = false;
                attackUpgrade1Done = true;
                //upgradeDoneText.gameObject.SetActive(true);
            }
        }
        else if (playerGold.gold < attack1.gold && playerLevel.Level >= attack1.level && attackUpgrade1Done == false) //if player gold is less than what is needed, change text color
        {
            Debug.Log(noGoldText);
            Debug.Log(showMessageTimer);
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
            }
        }
        else if (playerLevel.Level < attack1.level && playerGold.gold >= attack1.gold && attackUpgrade1Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                Debug.Log(noLevelText);
                Debug.Log(showMessageTimer);
            }
        }
        else if (playerGold.gold < attack1.gold && playerLevel.Level < attack1.level && attackUpgrade1Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            Debug.Log(noGoldOrLevelText);
            Debug.Log(showMessageTimer);
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
            }
        }
        else if (attackUpgrade1Done == true) //if player already did this upgrade
        {
            if (showMessageTimer > 0)
            {
                alreadyDidText.gameObject.SetActive(true);
                Debug.Log(alreadyDidText);
                Debug.Log(showMessageTimer);
            }
        }
    }

    private void AttackBtn2Clicked()
    {
        //write info about the upgtrade
        levelText.text = "Level: " + attack2.level;
        goldText.text = "Gold: " + attack2.gold;
        normalAtkText.text = "Normal Attack: +" + attack2.natk;
        strongAtkText.text = "Strong Attack: +" + attack2.satk;

        attackBtn2Active = true;

        attackBtn1Active = false;
        attackBtn3Active = false;
        attackBtn4Active = false;

        if (playerGold.gold >= attack2.gold && playerLevel.Level >= attack2.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && attackUpgrade1Done == true && attackUpgrade2Done == false)
            {
                playerAttackandBlock.normalPlayerAttack += attack2.natk;
                playerAttackandBlock.strongPlayerAttack += attack2.satk;
                doUpgradeIsClicked = false;
                attackUpgrade2Done = true;
            }
        }
        if (playerGold.gold < attack2.gold && playerLevel.Level >= attack2.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < attack2.level && playerGold.gold >= attack2.gold && attackUpgrade2Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < attack2.gold && playerLevel.Level < attack2.level && attackUpgrade2Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (attackUpgrade2Done == true) //if player already did this upgrade
        {
            if (showMessageTimer > 0)
            {
                alreadyDidText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
    }

    private void AttackBtn3Clicked()
    {
        //write info about the upgtrade
        levelText.text = "Level: " + attack3.level;
        goldText.text = "Gold: " + attack3.gold;
        normalAtkText.text = "Normal Attack: +" + attack3.natk;
        strongAtkText.text = "Strong Attack: +" + attack3.satk;

        attackBtn3Active = true;

        if (playerGold.gold >= attack3.gold && playerLevel.Level >= attack3.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && attackUpgrade2Done == true && attackUpgrade3Done == false)
            {
                playerAttackandBlock.normalPlayerAttack += attack3.natk;
                playerAttackandBlock.strongPlayerAttack += attack3.satk;
                doUpgradeIsClicked = false;
                attackUpgrade3Done = true;
            }
        }
        if (playerGold.gold < attack3.gold && playerLevel.Level >= attack3.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < attack3.level && playerGold.gold >= attack3.gold && attackUpgrade3Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < attack3.gold && playerLevel.Level < attack3.level && attackUpgrade3Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (attackUpgrade3Done == true) //if player already did this upgrade
        {
            if (showMessageTimer > 0)
            {
                alreadyDidText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
    }

    private void AttackBtn4Clicked()
    {
        //write info about the upgtrade
        levelText.text = "Level: " + attack4.level;
        goldText.text = "Gold: " + attack4.gold;
        normalAtkText.text = "Normal Attack: +" + attack4.natk;
        strongAtkText.text = "Strong Attack: +" + attack4.satk;

        attackBtn4Active = true;

        if (playerGold.gold >= attack4.gold && playerLevel.Level >= attack4.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && attackUpgrade3Done == true && attackUpgrade4Done == false)
            {
                playerAttackandBlock.normalPlayerAttack += attack4.natk;
                playerAttackandBlock.strongPlayerAttack += attack4.satk;
                doUpgradeIsClicked = false;
                attackUpgrade4Done = true;
            }
        }
        if (playerGold.gold < attack4.gold && playerLevel.Level >= attack4.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < attack4.level && playerGold.gold >= attack4.gold && attackUpgrade4Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < attack4.gold && playerLevel.Level < attack4.level && attackUpgrade4Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (attackUpgrade1Done == true) //if player already did this upgrade
        {
            if (showMessageTimer > 0)
            {
                alreadyDidText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
    }
}*/
