using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlimeLifeBar : MonoBehaviour
{
    //Files
    private BossSlimeLife bossslmeLife;

    //Sliders
    public Slider healthBar;

    //Texts
    public Text hpText;

    //GameObjects
    private GameObject target;

    void Start()
    {
        //Files
        bossslmeLife = FindObjectOfType<BossSlimeLife>();

        //GameObjects
        target = GameObject.FindGameObjectWithTag("Boss Slime");
    }

    void Update()
    {
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y + 2, transform.position.z);
        healthBar.maxValue = bossslmeLife.bossmaxlife;
        healthBar.value = bossslmeLife.life;
        hpText.text = "HP: " + bossslmeLife.life + " / " + bossslmeLife.bossmaxlife;
        healthBar.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
