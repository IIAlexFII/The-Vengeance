using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackUpImages : MonoBehaviour //change images
{
    //DoAttackUpgrades script
    private DoAttackUpgrades doAttackUpgrades;

    //GameObject Variables to access each attack upgrade object
    public GameObject upgradeObj1, upgradeObj2, upgradeObj3, upgradeObj4;

    //Bool Variables that will represent if the upgrade as been done or not ---> Code optimization
    private bool attack1, attack2, attack3, attack4;

    //Sprite Variables that will display image after upgraded
    public Sprite upgraded1, upgraded2, upgraded3, upgraded4;

    // Start is called before the first frame update
    void Start()
    {
        doAttackUpgrades = FindObjectOfType<DoAttackUpgrades>();
    }

    // Update is called once per frame
    void Update()
    {
        attack1 = doAttackUpgrades.upgrade1;
        attack2 = doAttackUpgrades.upgrade2;
        attack3 = doAttackUpgrades.upgrade3;
        attack4 = doAttackUpgrades.upgrade4;
        UpgradesImages();
    }

    //This method will change the upgrades images
    private void UpgradesImages()
    {
        if (attack1 == true)
        {
            upgradeObj1.GetComponent<Image>().sprite = upgraded1;
        }

        if (attack2 == true)
        {
            upgradeObj2.GetComponent<Image>().sprite = upgraded2;
        }

        if (attack3 == true)
        {
            upgradeObj3.GetComponent<Image>().sprite = upgraded3;
        }

        if (attack4 == true)
        {
            upgradeObj4.GetComponent<Image>().sprite = upgraded4;
        }
    }
}
