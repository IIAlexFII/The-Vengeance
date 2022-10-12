using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    //Files
    private PlayerGold playerGold;
    private PlayerLife playerLife;
    private PlayerLevel playerLevel;
    private PlayerController playerController;

    void Start()
    {
        playerGold = FindObjectOfType<PlayerGold>();
        playerLife = FindObjectOfType<PlayerLife>();
        playerLevel = FindObjectOfType<PlayerLevel>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.Alpha1)) || (Input.GetKeyUp(KeyCode.Keypad1)))
        {
            playerGold.gold += 10;
        }
        if ((Input.GetKeyUp(KeyCode.Alpha2)) || (Input.GetKeyUp(KeyCode.Keypad2)))
        {
            playerLife.life += 10;
        }
        if ((Input.GetKeyUp(KeyCode.Alpha3)) || (Input.GetKeyUp(KeyCode.Keypad3)))
        {
            playerLevel.exp += 20;
        }
        if ((Input.GetKeyUp(KeyCode.Alpha4)) || (Input.GetKeyUp(KeyCode.Keypad4)))
        {
            playerController.normalPlayerAttack += 10;
        }
        if ((Input.GetKeyUp(KeyCode.Alpha5)) || (Input.GetKeyUp(KeyCode.Keypad5)))
        {
            playerController.strongPlayerAttack += 10;
        }
        if ((Input.GetKeyUp(KeyCode.Alpha6)) || (Input.GetKeyUp(KeyCode.Keypad6)))
        {
            playerController.defensePlayer += 10;
        }
        if ((Input.GetKeyUp(KeyCode.Alpha7)) || (Input.GetKeyUp(KeyCode.Keypad7)))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
