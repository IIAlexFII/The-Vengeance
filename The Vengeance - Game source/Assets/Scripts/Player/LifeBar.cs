using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    //Files
    private PlayerLife playerLife;

    //Slider
    public Slider healthBar;

    //Text
    public Text hpText;

    void Start()
    {
        //File
        playerLife = FindObjectOfType<PlayerLife>();
    }

    void Update()
    {
        healthBar.maxValue = playerLife.maxlife;
        healthBar.value = playerLife.life;
        hpText.text = "HP: " + playerLife.life + " / " + playerLife.maxlife;
    }
}
