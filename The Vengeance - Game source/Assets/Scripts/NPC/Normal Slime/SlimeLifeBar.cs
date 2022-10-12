using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeLifeBar : MonoBehaviour
{
    private SlimeLife slimeLife;
    public Slider healthBar;
    public Text hpText;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        slimeLife = FindObjectOfType<SlimeLife>();
        target = GameObject.FindGameObjectWithTag("Melee Slime");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(target.transform.position.x, target.transform.position.y + 1.5f, transform.position.z);
        healthBar.maxValue = slimeLife.slimemaxlife;
        healthBar.value = slimeLife.slimelife;
        hpText.text = "HP: " + slimeLife.slimelife + " / " + slimeLife.slimemaxlife;
        healthBar.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
