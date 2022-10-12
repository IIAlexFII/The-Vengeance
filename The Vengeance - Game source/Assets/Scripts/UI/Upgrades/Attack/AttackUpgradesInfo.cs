using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackUpgradesInfo : MonoBehaviour //display info
{
    public Toggle attackToggle1, attackToggle2, attackToggle3, attackToggle4;

    public GameObject requirementsText, alreadyUpgraded;

    public Text levelText, goldText, normalAtkText, strongAtkText;

    private PlayerGold playerGold;
    private PlayerLevel playerLevel;
    private DoAttackUpgrades doAttackUpgrades;

    [HideInInspector] public HashTable attackdata;

    // Start is called before the first frame update
    void Start()
    {
        InitUpgradesHashtable();
        playerGold = FindObjectOfType<PlayerGold>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        doAttackUpgrades = FindObjectOfType<DoAttackUpgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        attackToggle1.onValueChanged.AddListener(delegate { ShowAttack1Requirements(); });
        attackToggle2.onValueChanged.AddListener(delegate { ShowAttack2Requirements(); });
        attackToggle3.onValueChanged.AddListener(delegate { ShowAttack3Requirements(); });
        attackToggle4.onValueChanged.AddListener(delegate { ShowAttack4Requirements(); });
    }

    //Inserting Upgrade Requirements on the Hashtable
    public void InitUpgradesHashtable()
    {
        attackdata = new HashTable(2);

        attackdata.Insert("Level1", 2); //level needed to do the upgrade
        attackdata.Insert("Gold1", 20); //gold needed to do the upgrade
        attackdata.Insert("NormalAttack1", 10); //normal attack power the player will receive
        attackdata.Insert("StrongAttack1", 5); //strong attack power the player will receive

        attackdata.Insert("Level2", 3); //level needed to do the upgrade
        attackdata.Insert("Gold2", 40); //gold needed to do the upgrade
        attackdata.Insert("NormalAttack2", 15); //normal attack power the player will receive
        attackdata.Insert("StrongAttack2", 10); //strong attack power the player will receive

        attackdata.Insert("Level3", 4); //level needed to do the upgrade
        attackdata.Insert("Gold3", 60); //gold needed to do the upgrade
        attackdata.Insert("NormalAttack3", 20); //normal attack power the player will receive
        attackdata.Insert("StrongAttack3", 15); //strong attack power the player will receive

        attackdata.Insert("Level4", 5); //level needed to do the upgrade
        attackdata.Insert("Gold4", 80); //gold needed to do the upgrade
        attackdata.Insert("NormalAttack4", 25); //normal attack power the player will receive
        attackdata.Insert("StrongAttack4", 20); //strong attack power the player will receive
    }

    private void ShowAttack1Requirements()
    {
        if (doAttackUpgrades.upgrade1 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade (get them from hashtable)
            levelText.text = "Level: " + (int)attackdata.GetValue("Level1");
            goldText.text = "Gold: " + (int)attackdata.GetValue("Gold1");
            normalAtkText.text = "Normal Attack: +" + (int)attackdata.GetValue("NormalAttack1");
            strongAtkText.text = "Strong Attack: +" + (int)attackdata.GetValue("StrongAttack1");

            if (playerGold.gold < (int)attackdata.GetValue("Gold1"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)attackdata.GetValue("Level1"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }
    }

    private void ShowAttack2Requirements()
    {
        if (doAttackUpgrades.upgrade2 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)attackdata.GetValue("Level2");
            goldText.text = "Gold: " + (int)attackdata.GetValue("Gold2");
            normalAtkText.text = "Normal Attack: +" + (int)attackdata.GetValue("NormalAttack2");
            strongAtkText.text = "Strong Attack: +" + (int)attackdata.GetValue("StrongAttack2");

            if (playerGold.gold < (int)attackdata.GetValue("Gold2"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)attackdata.GetValue("Level2"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }
    }

    private void ShowAttack3Requirements()
    {
        if (doAttackUpgrades.upgrade3 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)attackdata.GetValue("Level3");
            goldText.text = "Gold: " + (int)attackdata.GetValue("Gold3");
            normalAtkText.text = "Normal Attack: +" + (int)attackdata.GetValue("NormalAttack3");
            strongAtkText.text = "Strong Attack: +" + (int)attackdata.GetValue("StrongAttack3");

            if (playerGold.gold < (int)attackdata.GetValue("Gold3"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)attackdata.GetValue("Level3"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }
    }

    private void ShowAttack4Requirements()
    {
        if (doAttackUpgrades.upgrade4 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)attackdata.GetValue("Level4");
            goldText.text = "Gold: " + (int)attackdata.GetValue("Gold4");
            normalAtkText.text = "Normal Attack: +" + (int)attackdata.GetValue("NormalAttack4");
            strongAtkText.text = "Strong Attack: +" + (int)attackdata.GetValue("StrongAttack4");

            if (playerGold.gold < (int)attackdata.GetValue("Gold4"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)attackdata.GetValue("Level4"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }
    }

}
