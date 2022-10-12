using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    //Files
    private PlayerLevel playerLevel;

    //Slider
    public Slider expBar;

    //Texts
    public Text exptext;

    void Start()
    {
        //File
        playerLevel = FindObjectOfType<PlayerLevel>();
    }

    void Update()
    {
        expBar.maxValue = playerLevel.maxexp[playerLevel.arrayPoints];
        expBar.value = playerLevel.exp;
        exptext.text = "EXP: " + playerLevel.exp + " / " + playerLevel.maxexp[playerLevel.arrayPoints];
    }
}
