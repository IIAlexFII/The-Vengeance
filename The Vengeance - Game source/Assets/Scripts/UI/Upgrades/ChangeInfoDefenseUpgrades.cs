using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*public class ChangeInfoDefenseUpgrades : MonoBehaviour
{
    private PlayerAttackandBlock playerAttackandBlock;
    private PlayerGold playerGold;
    private PlayerLevel playerLevel;
    private OpenUpgrades openUpgrades;

    public Button defenseUpgrade1;
    public Button defenseUpgrade2;
    public Button defenseUpgrade3;
    public Button defenseUpgrade4;
    public Button doUpgrade;

    public GameObject noGoldText; //player has no gold but still trys to do the upgrade
    public GameObject noLevelText; //player has a lower level than what is needed but still trys to do the upgrade
    public GameObject noGoldOrLevelText;
    public GameObject alreadyDidText; //player did this upgrade before but trys to do it again
    public GameObject upgradeDoneText; //player has gold, level and didn't do this upgrade before and does the upgrade

    public float showMessageCoolDownTimer = 2f;
    private float showMessageTimer = 0;

    public Text levelText;
    public Text goldText;
    public Text defText;

    private Defense defense1;
    private Defense defense2;
    private Defense defense3;
    private Defense defense4;

    public bool doUpgradeIsClicked = false;

    public bool defenseBtn1Active = false;
    public bool defenseBtn2Active = false;
    public bool defenseBtn3Active = false;
    public bool defenseBtn4Active = false;

    public bool defenseUpgrade1Done = false;
    public bool defenseUpgrade2Done = false;
    public bool defenseUpgrade3Done = false;
    public bool defenseUpgrade4Done = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAttackandBlock = FindObjectOfType<PlayerAttackandBlock>();
        playerGold = FindObjectOfType<PlayerGold>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        openUpgrades = FindObjectOfType<OpenUpgrades>();

        defense1 = new Defense();
        defense1.level = 2;
        defense1.gold = 20;
        defense1.def = 10; // def - defense

        defense2 = new Defense();
        defense2.level = 3;
        defense2.gold = 40;
        defense2.def = 15;

        defense3 = new Defense();
        defense3.level = 4;
        defense3.gold = 60;
        defense3.def = 20;

        defense4 = new Defense();
        defense4.level = 5;
        defense4.gold = 80;
        defense4.def = 25;
    }

    void Update()
    {
        Cursor.visible = true;

        defenseUpgrade1.onClick.AddListener(AttackBtn1Clicked);
        defenseUpgrade2.onClick.AddListener(AttackBtn2Clicked);
        defenseUpgrade3.onClick.AddListener(AttackBtn3Clicked);
        defenseUpgrade4.onClick.AddListener(AttackBtn4Clicked);

        doUpgrade.onClick.AddListener(DoUpgradeBtnIsClicked);
    }

    private void DoUpgradeBtnIsClicked()
    {
        doUpgradeIsClicked = true;
    }

    private void AttackBtn1Clicked()
    {
        //write info about the upgtrade
        levelText.text = "Level: " + defense1.level;
        goldText.text = "Gold: " + defense1.gold;
        defText.text = "Normal Attack: +" + defense1.def;

        defenseBtn1Active = true;

        if (playerGold.gold >= defense1.gold && playerLevel.Level >= defense1.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && defenseUpgrade1Done == false)
            {
                playerAttackandBlock.defensePlayer += defense1.def;
                doUpgradeIsClicked = false;
                defenseUpgrade1Done = true;
            }
        }
        if (playerGold.gold < defense1.gold && playerLevel.Level >= defense1.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < defense1.level && playerGold.gold >= defense1.gold && defenseUpgrade1Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < defense1.gold && playerLevel.Level < defense1.level && defenseUpgrade1Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (defenseUpgrade1Done == true) //if player already did this upgrade
        {
            if (showMessageTimer > 0)
            {
                alreadyDidText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
    }

    private void AttackBtn2Clicked()
    {
        //write info about the upgtrade
        levelText.text = "Level: " + defense2.level;
        goldText.text = "Gold: " + defense2.gold;
        defText.text = "Normal Attack: +" + defense2.def;

        defenseBtn2Active = true;

        if (playerGold.gold >= defense2.gold && playerLevel.Level >= defense2.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && defenseUpgrade1Done == true && defenseUpgrade2Done == false)
            {
                playerAttackandBlock.defensePlayer += defense2.def;
                doUpgradeIsClicked = false;
                defenseUpgrade2Done = true;
            }
        }
        if (playerGold.gold < defense2.gold && playerLevel.Level >= defense2.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < defense2.level && playerGold.gold >= defense2.gold && defenseUpgrade2Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < defense2.gold && playerLevel.Level < defense2.level && defenseUpgrade2Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (defenseUpgrade2Done == true) //if player already did this upgrade
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
        levelText.text = "Level: " + defense3.level;
        goldText.text = "Gold: " + defense3.gold;
        defText.text = "Normal Attack: +" + defense3.def;

        defenseBtn3Active = true;

        if (playerGold.gold >= defense3.gold && playerLevel.Level >= defense3.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && defenseUpgrade2Done == true && defenseUpgrade3Done == false)
            {
                playerAttackandBlock.defensePlayer += defense3.def;
                doUpgradeIsClicked = false;
                defenseUpgrade3Done = true;
            }
        }
        if (playerGold.gold < defense3.gold && playerLevel.Level >= defense3.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < defense3.level && playerGold.gold >= defense3.gold && defenseUpgrade3Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < defense3.gold && playerLevel.Level < defense3.level && defenseUpgrade3Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (defenseUpgrade3Done == true) //if player already did this upgrade
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
        levelText.text = "Level: " + defense4.level;
        goldText.text = "Gold: " + defense4.gold;
        defText.text = "Normal Attack: +" + defense4.def;

        defenseBtn4Active = true;

        if (playerGold.gold >= defense4.gold && playerLevel.Level >= defense4.level) //if player gold and level is more or equal than what is needed
        {
            if (doUpgradeIsClicked == true && defenseUpgrade3Done == true && defenseUpgrade4Done == false)
            {
                playerAttackandBlock.defensePlayer += defense4.def;
                doUpgradeIsClicked = false;
                defenseUpgrade4Done = true;
            }
        }
        if (playerGold.gold < defense4.gold && playerLevel.Level >= defense4.level) //if player gold is less than what is needed, change text color
        {
            goldText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerLevel.Level < defense4.level && playerGold.gold >= defense4.gold && defenseUpgrade4Done == false) //if player level is less than what is needed, change text color
        {
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (playerGold.gold < defense4.gold && playerLevel.Level < defense4.level && defenseUpgrade4Done == false) //if player level and gold are less than ehat is needed, change text color
        {
            goldText.color = Color.red;
            levelText.color = Color.red;
            if (showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
        else if (defenseUpgrade4Done == true) //if player already did this upgrade
        {
            if (showMessageTimer > 0)
            {
                alreadyDidText.gameObject.SetActive(true);
                showMessageTimer -= Time.deltaTime;
            }
        }
    }
}*/
