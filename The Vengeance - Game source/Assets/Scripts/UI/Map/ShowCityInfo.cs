using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCityInfo : MonoBehaviour
{
    public Button exitButtonTravelPanel, city1TravelButton, city2TravelButton;

    public Toggle city1Toggle, city2Toggle;

    public GameObject mapPanel;
    public GameObject city1Panel, city2Panel;

    private TravelNPC travelNpcScript;
    private TravelNPC2 travelNpcScript2;

    // Start is called before the first frame update
    void Start()
    {
        travelNpcScript = FindObjectOfType<TravelNPC>();
        travelNpcScript2 = FindObjectOfType<TravelNPC2>();

        city1Panel.gameObject.SetActive(false);
        city2Panel.gameObject.SetActive(false);

        city1Toggle.isOn = false;
        city2Toggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        exitButtonTravelPanel.onClick.AddListener(CloseMapPanel);
        CityInfo();
        ShowButtons();
    }

    private void CityInfo()
    {
        if (city1Toggle.isOn == true)
        {
            city1Panel.gameObject.SetActive(true);
            city2Panel.gameObject.SetActive(false);
        }

        else if (city2Toggle.isOn == true)
        {
            city2Panel.gameObject.SetActive(true);
            city1Panel.gameObject.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        if (travelNpcScript.travelCity1Selected == true)
        {
            city1TravelButton.gameObject.SetActive(false);
            city2TravelButton.gameObject.SetActive(true);
        }

        if (travelNpcScript2.travelCity2Selected == true)
        {
            city1TravelButton.gameObject.SetActive(true);
            city2TravelButton.gameObject.SetActive(false);
        }
    }

    private void CloseMapPanel()
    {

        travelNpcScript.accepted = false;
        travelNpcScript.travelCity1Selected = false;

        travelNpcScript2.travelCity2Selected = false;
        travelNpcScript2.accepted = false;


        city1Toggle.isOn = false;
        city2Toggle.isOn = false;

        mapPanel.gameObject.SetActive(false);

        city1Panel.gameObject.SetActive(false);
        city2Panel.gameObject.SetActive(false);

    }
}
