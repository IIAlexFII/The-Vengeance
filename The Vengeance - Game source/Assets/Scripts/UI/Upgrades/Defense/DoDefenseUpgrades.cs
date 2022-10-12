using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoDefenseUpgrades : MonoBehaviour
{
    public GameObject noGoldText; //player has no gold but still trys to do the upgrade
    public GameObject noLevelText; //player has a lower level than what is needed but still trys to do the upgrade
    public GameObject noGoldOrLevelText; //Both previous ones
    public GameObject upgradedText;

    public float showMessageCoolDownTimer = 2f;
    public float showUpgradedcoolDownTimer = 1f;

    private DefenseUpgradesInfo defenseUpgradesInfo;
    private Toggle defensekUp1, defensekUp2, defensekUp3, defensekUp4;

    private Button doUpgradeButton;

    private PlayerGold playerGold;
    private PlayerLevel playerLevel;
    private PlayerController playerController;

    private float showMessageTimer = 0;
    private float showUpgradedMessageTimer = 0;

    private int defense1, defense2, defense3, defense4;
    private int levelUp1, levelUp2, levelUp3, levelUp4;
    private int goldUp1, goldUp2, goldUp3, goldUp4;

    [HideInInspector]public bool upgrade1, upgrade2, upgrade3, upgrade4;

    // Start is called before the first frame update
    void Start()
    {
        defenseUpgradesInfo = FindObjectOfType<DefenseUpgradesInfo>();
        playerGold = FindObjectOfType<PlayerGold>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        playerController = FindObjectOfType<PlayerController>();
        doUpgradeButton = GetComponent<Button>();

        upgrade1 = false;
        upgrade2 = false;
        upgrade3 = false;
        upgrade4 = false;

        noGoldText.gameObject.SetActive(false);
        noLevelText.gameObject.SetActive(false);
        noGoldOrLevelText.gameObject.SetActive(false);

        defensekUp1 = defenseUpgradesInfo.defenseToggle1;
        defensekUp2 = defenseUpgradesInfo.defenseToggle2;
        defensekUp3 = defenseUpgradesInfo.defenseToggle3;
        defensekUp4 = defenseUpgradesInfo.defenseToggle4;

        levelUp1 = (int)defenseUpgradesInfo.defensedata.GetValue("Level1"); //get info from hashtable in the defenseupgradesinfo.cs file
        levelUp2 = (int)defenseUpgradesInfo.defensedata.GetValue("Level2");
        levelUp3 = (int)defenseUpgradesInfo.defensedata.GetValue("Level3");
        levelUp4 = (int)defenseUpgradesInfo.defensedata.GetValue("Level4");

        goldUp1 = (int)defenseUpgradesInfo.defensedata.GetValue("Gold1");
        goldUp2 = (int)defenseUpgradesInfo.defensedata.GetValue("Gold2");
        goldUp3 = (int)defenseUpgradesInfo.defensedata.GetValue("Gold3");
        goldUp4 = (int)defenseUpgradesInfo.defensedata.GetValue("Gold4");

        defense1 = (int)defenseUpgradesInfo.defensedata.GetValue("Defense1");
        defense2 = (int)defenseUpgradesInfo.defensedata.GetValue("Defense2");
        defense3 = (int)defenseUpgradesInfo.defensedata.GetValue("Defense3");
        defense4 = (int)defenseUpgradesInfo.defensedata.GetValue("Defense4");
    }

    // Update is called once per frame
    void Update()
    {
        doUpgradeButton.onClick.AddListener(Upgrade);
        MessageTimer();
        UpgradedMessageTimer();
    }

    private void Upgrade()
    {
        if (defensekUp1.isOn == true )
        {
            if (playerLevel.Level >= levelUp1 && playerGold.gold >= goldUp1 && upgrade1 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.defensePlayer += defense1;
                playerGold.gold -= goldUp1;
                upgrade1 = true;
            }

            else if (playerLevel.Level < levelUp1 && playerGold.gold >= goldUp1 && upgrade1 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp1 && playerLevel.Level >= levelUp1 && upgrade1 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp1 && playerLevel.Level < levelUp1 && upgrade1 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
            }
        }

        else if (defensekUp2.isOn == true)
        {
            if (playerLevel.Level >= levelUp2 && playerGold.gold >= goldUp2 && upgrade2 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.defensePlayer += defense2;
                playerGold.gold -= goldUp2;
                upgrade2 = true;
            }

            else if (playerLevel.Level < levelUp2 && playerGold.gold >= goldUp2 && upgrade2 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp2 && playerLevel.Level >= levelUp2 && upgrade2 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp2 && playerLevel.Level < levelUp2 && upgrade2 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
            }
        }

        else if (defensekUp3.isOn == true)
        {
            if (playerLevel.Level >= levelUp3 && playerGold.gold >= goldUp3 && upgrade3 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.defensePlayer += defense3;
                playerGold.gold -= goldUp3;
                upgrade3 = true;
            }

            else if (playerLevel.Level < levelUp3 && playerGold.gold >= goldUp3 && upgrade3 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp3 && playerLevel.Level >= levelUp3 && upgrade3 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp3 && playerLevel.Level < levelUp3 && upgrade3 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
            }
        }

        else if (defensekUp4.isOn == true)
        {
            if (playerLevel.Level >= levelUp4 && playerGold.gold >= goldUp4 && upgrade4 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.defensePlayer += defense4;
                playerGold.gold -= goldUp4;
                upgrade4 = true;
            }

            else if (playerLevel.Level < levelUp4 && playerGold.gold >= goldUp4 && upgrade4 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp4 && playerLevel.Level >= levelUp4 && upgrade4 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
            }

            else if (playerGold.gold < goldUp4 && playerLevel.Level < levelUp4 && upgrade4 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
            }
        }
        showMessageTimer = showMessageCoolDownTimer;
        showUpgradedMessageTimer = showUpgradedcoolDownTimer;
    }

    private void MessageTimer()
    {
        if (showMessageTimer <= 0)
        {
            noGoldText.gameObject.SetActive(false);
            noLevelText.gameObject.SetActive(false);
            noGoldOrLevelText.gameObject.SetActive(false);
        }
        else
        {
            showMessageTimer -= Time.deltaTime;
        }
    }

    private void UpgradedMessageTimer()
    {
        if (showMessageTimer <= 0)
        {
            upgradedText.gameObject.SetActive(false);
        }
        else
        {
            showUpgradedMessageTimer -= Time.deltaTime;
        }

    }
}
