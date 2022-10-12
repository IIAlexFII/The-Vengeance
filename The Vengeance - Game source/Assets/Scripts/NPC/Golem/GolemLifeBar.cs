using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemLifeBar : MonoBehaviour
{
    //Files
    private GolemLife golemLife;

    //Sliders
    public Slider healthBar;

    //Texts
    public Text hpText;

    //GameObjects
    private GameObject target;

    void Start()
    {
        //Files
        golemLife = FindObjectOfType<GolemLife>();

        //GameObjects
        target = GameObject.FindGameObjectWithTag("Golem");
    }

    void Update()
    {
        //Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y + 2, transform.position.z);
        healthBar.maxValue = golemLife.golemMaxlife;
        healthBar.value = golemLife.life;
        hpText.text = golemLife.life + " / " + golemLife.golemMaxlife;
        //healthBar.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
