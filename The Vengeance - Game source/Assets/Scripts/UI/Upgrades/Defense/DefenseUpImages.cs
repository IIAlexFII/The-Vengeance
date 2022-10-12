using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenseUpImages : MonoBehaviour
{
    //DoDefenseUpgrades script
    private DoDefenseUpgrades doDefenseUpgrades;

    //GameObject Variables to access each defense upgrade object
    public GameObject upgradeObj1, upgradeObj2, upgradeObj3, upgradeObj4;

    //Bool Variables that will represent if the upgrade as been done or not ---> Variable size optimization
    private bool defense1, defense2, defense3, defense4;

    //Sprite Variables that will display image after upgraded
    public Sprite upgraded1, upgraded2, upgraded3, upgraded4;

    // Start is called before the first frame update
    void Start()
    {
        doDefenseUpgrades = FindObjectOfType<DoDefenseUpgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        defense1 = doDefenseUpgrades.upgrade1;
        defense2 = doDefenseUpgrades.upgrade2;
        defense3 = doDefenseUpgrades.upgrade3;
        defense4 = doDefenseUpgrades.upgrade4;
        UpgradesImages();
    }

    //This method will change the upgrades images
    private void UpgradesImages()
    {
        if (defense1 == true)
        {
            upgradeObj1.GetComponent<Image>().sprite = upgraded1;
        }

        if (defense2 == true)
        {
            upgradeObj2.GetComponent<Image>().sprite = upgraded2;
        }

        if (defense3 == true)
        {
            upgradeObj3.GetComponent<Image>().sprite = upgraded3;
        }

        if (defense4 == true)
        {
            upgradeObj4.GetComponent<Image>().sprite = upgraded4;
        }
    }
}
