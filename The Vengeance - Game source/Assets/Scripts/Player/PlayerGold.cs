using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour
{
    //Files
    private OpenUpgrades openUpgrades;

    //Ints
    public int gold;

    //Texts
    public Text goldText;
    public Text goldTextUpgrades;

    private void Start()
    {
        openUpgrades = FindObjectOfType<OpenUpgrades>();
        gold = PlayerData.loginInfo.score;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "" + gold;
        if (openUpgrades != null)
        {
            goldTextUpgrades.text = "" + gold;
        }
    }
}
