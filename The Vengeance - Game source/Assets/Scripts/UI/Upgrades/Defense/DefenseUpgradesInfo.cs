using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DefenseUpgradesInfo : MonoBehaviour
{
    public Toggle defenseToggle1, defenseToggle2, defenseToggle3, defenseToggle4;

    public GameObject requirementsText, alreadyUpgraded;

    public Text levelText, goldText, defenseText;

    private PlayerGold playerGold;
    private PlayerLevel playerLevel;
    private DoDefenseUpgrades doDefenseUpgrades;

    [HideInInspector] public HashTable defensedata;

    // Start is called before the first frame update
    void Start()
    {
        InitUpgradesHashtable();
        playerGold = FindObjectOfType<PlayerGold>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        doDefenseUpgrades = FindObjectOfType<DoDefenseUpgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        defenseToggle1.onValueChanged.AddListener(delegate { ShowDefense1Requirements(); });
        defenseToggle2.onValueChanged.AddListener(delegate { ShowDefense2Requirements(); });
        defenseToggle3.onValueChanged.AddListener(delegate { ShowDefense3Requirements(); });
        defenseToggle4.onValueChanged.AddListener(delegate { ShowDefense4Requirements(); });
    }

    //Inserting Upgrade Requirements on the Hashtable
    public void InitUpgradesHashtable()
    {
        defensedata = new HashTable(2);

        defensedata.Insert("Level1", 2); //level needed to do the upgrade
        defensedata.Insert("Gold1", 20); //gold needed to do the upgrade
        defensedata.Insert("Defense1", 10); //defense power the player will receive

        defensedata.Insert("Level2", 3); //level needed to do the upgrade
        defensedata.Insert("Gold2", 40); //gold needed to do the upgrade
        defensedata.Insert("Defense2", 15); //defense power the player will receive

        defensedata.Insert("Level3", 4); //level needed to do the upgrade
        defensedata.Insert("Gold3", 60); //gold needed to do the upgrade
        defensedata.Insert("Defense3", 20); //defense power the player will receive

        defensedata.Insert("Level4", 5); //level needed to do the upgrade
        defensedata.Insert("Gold4", 80); //gold needed to do the upgrade
        defensedata.Insert("Defense4", 25); //defense power the player will receive
    }

    private void ShowDefense1Requirements()
    {
        if (doDefenseUpgrades.upgrade1 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)defensedata.GetValue("Level1");
            goldText.text = "Gold: " + (int)defensedata.GetValue("Gold1");
            defenseText.text = "Defense: +" + (int)defensedata.GetValue("Defense1");

            if (playerGold.gold < (int)defensedata.GetValue("Gold1"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)defensedata.GetValue("Level1"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }

    }

    private void ShowDefense2Requirements()
    {
        if (doDefenseUpgrades.upgrade2 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)defensedata.GetValue("Level2");
            goldText.text = "Gold: " + (int)defensedata.GetValue("Gold2");
            defenseText.text = "Defense: +" + (int)defensedata.GetValue("Defense2");

            if (playerGold.gold < (int)defensedata.GetValue("Gold2"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)defensedata.GetValue("Level2"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }
    }

    private void ShowDefense3Requirements()
    {
        if (doDefenseUpgrades.upgrade3 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)defensedata.GetValue("Level3");
            goldText.text = "Gold: " + (int)defensedata.GetValue("Gold3");
            defenseText.text = "Defense: +" + (int)defensedata.GetValue("Defense3");

            if (playerGold.gold < (int)defensedata.GetValue("Gold3"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)defensedata.GetValue("Level3"))
                levelText.color = Color.red;
            else levelText.color = Color.black;
        }

        else
        {
            requirementsText.gameObject.SetActive(false);
            alreadyUpgraded.gameObject.SetActive(true);
        }

    }

    private void ShowDefense4Requirements()
    {
        if (doDefenseUpgrades.upgrade4 == false)
        {
            requirementsText.gameObject.SetActive(true);
            alreadyUpgraded.gameObject.SetActive(false);

            //write info about the upgtrade
            levelText.text = "Level: " + (int)defensedata.GetValue("Level4");
            goldText.text = "Gold: " + (int)defensedata.GetValue("Gold4");
            defenseText.text = "Defense: +" + (int)defensedata.GetValue("Defense4");

            if (playerGold.gold < (int)defensedata.GetValue("Gold4"))
                goldText.color = Color.red;
            else goldText.color = Color.black;

            if (playerLevel.Level < (int)defensedata.GetValue("Level4"))
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
