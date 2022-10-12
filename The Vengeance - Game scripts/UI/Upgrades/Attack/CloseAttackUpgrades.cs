using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAttackUpgrades : MonoBehaviour
{
    //Button variable
    public Button exitUpgradesButton;

    // Update is called once per frame
    void Update()
    {
        exitUpgradesButton.onClick.AddListener(ClosePanel);
    }
    
    //Method to close the attack upgrades panel
    void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
