using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUpgrades : MonoBehaviour
{
    //Text Objects that will display the player stats
    public Text basicAttack, strongAttack, defense;

    //Player Controller Script
    private PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
    }

    //This method displays the player stats
    private void DisplayStats()
    {
        basicAttack.text = "Normal Attack: " + playerController.normalPlayerAttack;
        strongAttack.text = "Strong Attack: " + playerController.strongPlayerAttack;
        defense.text = "Defense: " + playerController.defensePlayer;
    }
}
