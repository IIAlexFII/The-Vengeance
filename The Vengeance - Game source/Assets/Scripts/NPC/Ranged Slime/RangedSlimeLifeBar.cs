using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedSlimeLifeBar : MonoBehaviour
{
    //private RangedSlimeLife rangedSlimeLife;
    public Slider healthBar;
    public Text hpText;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //rangedSlimeLife = FindObjectOfType<RangedSlimeLife>();
        target = GameObject.FindGameObjectWithTag("Ranged Slime");
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y + 2, transform.position.z);
        healthBar.maxValue = rangedSlimeLife.rangeSlimeMaxLife;
        healthBar.value = rangedSlimeLife.life;
        hpText.text = "HP: " + rangedSlimeLife.life + " / " + rangedSlimeLife.rangeSlimeMaxLife;
        healthBar.transform.position = Camera.main.WorldToScreenPoint(pos);
    }*/
}
