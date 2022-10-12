using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoAttackUpgrades : MonoBehaviour
{
    //GameObject Variables
    public GameObject noGoldText; //player has no gold but still trys to do the upgrade
    public GameObject noLevelText; //player has a lower level than what is needed but still trys to do the upgrade
    public GameObject noGoldOrLevelText; //Both previous ones
    public GameObject upgradedText;

    //Toggle Variables
    private Toggle attackUp1, attackUp2, attackUp3, attackUp4;

    //Button Variables
    private Button doUpgradeButton; //Upgrade Button

    //Script Variables
    private PlayerGold playerGold;
    private PlayerLevel playerLevel;
    private PlayerController playerController;
    private AttackUpgradesInfo attackUpgradesInfo;

    //Float Variables ---> Timers
    private float showMessageTimer = 0;
    private float showUpgradedMessageTimer = 0;

    //Float Variables ---> Cooldown Timers
    public float showMessageCoolDownTimer = 1f;
    public float showUpgradedcoolDownTimer = 1f;

    //Int Variables ---> This variables will store the Hashatable normal attack values
    private int normalAttack1, normalAttack2, normalAttack3, normalAttack4;

    //Int Variables ---> This variables will store the Hashatable strong attack values
    private int strongAttack1, strongAttack2, strongAttack3, strongAttack4;

    //Int Variables ---> This variables will store the Hashatable level values
    private int levelUp1, levelUp2, levelUp3, levelUp4;

    //Int Variables ---> This variables will store the Hashatable gold values
    private int goldUp1, goldUp2, goldUp3, goldUp4;

    //Bool Variables ---> This variables will define if the upgrade is done or not
    [HideInInspector] public bool upgrade1, upgrade2, upgrade3, upgrade4;
    [HideInInspector] public bool cantUpgradeMessage;

    // Start is called before the first frame update
    void Start()
    {
        cantUpgradeMessage = false;
        attackUpgradesInfo = FindObjectOfType<AttackUpgradesInfo>();
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

        attackUp1 = attackUpgradesInfo.attackToggle1;
        attackUp2 = attackUpgradesInfo.attackToggle2;
        attackUp3 = attackUpgradesInfo.attackToggle3;
        attackUp4 = attackUpgradesInfo.attackToggle4;

        levelUp1 = (int)attackUpgradesInfo.attackdata.GetValue("Level1"); //get info from hashtable in the attackupgradesinfo.cs file
        levelUp2 = (int)attackUpgradesInfo.attackdata.GetValue("Level2");
        levelUp3 = (int)attackUpgradesInfo.attackdata.GetValue("Level3");
        levelUp4 = (int)attackUpgradesInfo.attackdata.GetValue("Level4");

        goldUp1 = (int)attackUpgradesInfo.attackdata.GetValue("Gold1");
        goldUp2 = (int)attackUpgradesInfo.attackdata.GetValue("Gold2");
        goldUp3 = (int)attackUpgradesInfo.attackdata.GetValue("Gold3");
        goldUp4 = (int)attackUpgradesInfo.attackdata.GetValue("Gold4");

        normalAttack1 = (int)attackUpgradesInfo.attackdata.GetValue("NormalAttack1");
        normalAttack2 = (int)attackUpgradesInfo.attackdata.GetValue("NormalAttack2");
        normalAttack3 = (int)attackUpgradesInfo.attackdata.GetValue("NormalAttack3");
        normalAttack4 = (int)attackUpgradesInfo.attackdata.GetValue("NormalAttack4");

        strongAttack1 = (int)attackUpgradesInfo.attackdata.GetValue("StrongAttack1");
        strongAttack2 = (int)attackUpgradesInfo.attackdata.GetValue("StrongAttack2");
        strongAttack3 = (int)attackUpgradesInfo.attackdata.GetValue("StrongAttack3");
        strongAttack4 = (int)attackUpgradesInfo.attackdata.GetValue("StrongAttack4");
    }

    // Update is called once per frame
    void Update()
    {
        doUpgradeButton.onClick.AddListener(Upgrade);
        MessageTimer();
        UpgradedMessageTimer();
    }

    //This method will run after the player pressed Upgrade Button
    //Will check if the player have requirements to do the upgrades
    private void Upgrade()
    {
        if (attackUp1.isOn == true)
        {
            if (playerLevel.Level >= levelUp1 && playerGold.gold >= goldUp1 && upgrade1 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.normalPlayerAttack += normalAttack1;
                playerController.strongPlayerAttack += strongAttack1;
                playerGold.gold -= goldUp1;
                upgrade1 = true;
            }

            else if (playerLevel.Level < levelUp1 && playerGold.gold >= goldUp1 && upgrade1 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp1 && playerLevel.Level >= levelUp1 && upgrade1 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp1 && playerLevel.Level < levelUp1 && upgrade1 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }
        }

        else if (attackUp2.isOn == true)
        {
            if (playerLevel.Level >= levelUp2 && playerGold.gold >= goldUp2 && upgrade2 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.normalPlayerAttack += normalAttack2;
                playerController.strongPlayerAttack += strongAttack2;
                playerGold.gold -= goldUp2;
                upgrade2 = true;
            }

            else if (playerLevel.Level < levelUp2 && playerGold.gold >= goldUp2 && upgrade2 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp2 && playerLevel.Level >= levelUp2 && upgrade2 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp2 && playerLevel.Level < levelUp2 && upgrade2 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }
        }

        else if (attackUp3.isOn == true)
        {
            if (playerLevel.Level >= levelUp3 && playerGold.gold >= goldUp3 && upgrade3 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.normalPlayerAttack += normalAttack3;
                playerController.strongPlayerAttack += strongAttack3;
                playerGold.gold -= goldUp3;
                upgrade3 = true;
            }

            else if (playerLevel.Level < levelUp3 && playerGold.gold >= goldUp3 && upgrade3 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp3 && playerLevel.Level >= levelUp3 && upgrade3 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp3 && playerLevel.Level < levelUp3 && upgrade3 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }
        }

        else if (attackUp4.isOn == true)
        {
            if (playerLevel.Level >= levelUp4 && playerGold.gold >= goldUp4 && upgrade4 == false && showUpgradedMessageTimer > 0)
            {
                upgradedText.gameObject.SetActive(true);
                playerController.normalPlayerAttack += normalAttack4;
                playerController.strongPlayerAttack += strongAttack4;
                playerGold.gold -= goldUp4;
                upgrade4 = true;
            }

            else if (playerLevel.Level < levelUp4 && playerGold.gold >= goldUp4 && upgrade4 == false && showMessageTimer > 0)
            {
                noLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp4 && playerLevel.Level >= levelUp4 && upgrade4 == false && showMessageTimer > 0)
            {
                noGoldText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }

            else if (playerGold.gold < goldUp4 && playerLevel.Level < levelUp4 && upgrade4 == false && showMessageTimer > 0)
            {
                noGoldOrLevelText.gameObject.SetActive(true);
                cantUpgradeMessage = true;
            }
        }
        showMessageTimer = showMessageCoolDownTimer;
        showUpgradedMessageTimer = showUpgradedcoolDownTimer;
    }

    //This method will activate the timer for all the messages related to the upgrades
    private void MessageTimer()
    {
        if (showMessageTimer <= 0)
        {
            upgradedText.gameObject.SetActive(false);
            noGoldText.gameObject.SetActive(false);
            noLevelText.gameObject.SetActive(false);
            noGoldOrLevelText.gameObject.SetActive(false);
            cantUpgradeMessage = false;
        }
        else
        {
            showMessageTimer -= Time.deltaTime;
        }
    }

    //This method will activate the timer for all the messages related to the upgrades
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
