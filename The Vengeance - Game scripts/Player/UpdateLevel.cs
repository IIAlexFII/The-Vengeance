using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour
{
    //File
    private PlayerLevel playerLevel;

    //Text
    public Text levelText;

    void Start()
    {
        //File
        playerLevel = FindObjectOfType<PlayerLevel>();
    }

    void Update()
    {
        levelText.text = "" + playerLevel.Level;
    }
}
