using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkelLifeBar : MonoBehaviour
{
    private GameObject lifeBar;
    public GameObject lifeBarPrefab;
    private Transform canvasPos;


    //Files
    private SkelLife skelLife;

    //Sliders
    //public Slider healthBar;

    //Texts
    //public Text hpText;

    void Start()
    {
        //Files
        skelLife = gameObject.GetComponent<SkelLife>();

        //GameObjects

        canvasPos = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Transform>();

        lifeBar = Instantiate(lifeBarPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity, canvasPos);
    }

    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        lifeBar.GetComponent<Slider>().maxValue = skelLife.skelMaxLife;
        lifeBar.GetComponent<Slider>().value = skelLife.life;

        lifeBar.GetComponent<Slider>().transform.position = Camera.main.WorldToScreenPoint(pos);

        if (skelLife.life <= 0)
        {
            Destroy(lifeBar);
        }

        //healthBar.maxValue = orcLife.orcMaxLife;
        //healthBar.value = orcLife.life;
        //hpText.text = "HP: " + orcLife.life + " / " + orcLife.orcMaxLife;
        //healthBar.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
