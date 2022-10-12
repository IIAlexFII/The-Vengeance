using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrcLifeBar : MonoBehaviour
{
    private GameObject lifeBar;
    public GameObject lifeBarPrefab;
    private Transform canvasPos;

    
    //Files
    private OrcLife orcLife;

    //Sliders
    //public Slider healthBar;

    //Texts
    //public Text hpText;

    void Start()
    {
        //Files
        orcLife = gameObject.GetComponent<OrcLife>();

        //GameObjects

        canvasPos = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<Transform>();

        lifeBar = Instantiate(lifeBarPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity, canvasPos); //instantiate the lifebar once the orc is instatiated
    }
    
    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        lifeBar.GetComponent<Slider>().maxValue = orcLife.orcMaxLife;
        lifeBar.GetComponent<Slider>().value = orcLife.life;

        lifeBar.GetComponent<Slider>().transform.position = Camera.main.WorldToScreenPoint(pos);

        if (orcLife.life <= 0)
        {
            Destroy(lifeBar);
        }

        //healthBar.maxValue = orcLife.orcMaxLife;
        //healthBar.value = orcLife.life;
        //hpText.text = "HP: " + orcLife.life + " / " + orcLife.orcMaxLife;
        //healthBar.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
