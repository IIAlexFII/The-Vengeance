using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTravel : MonoBehaviour
{
    public GameObject city1Panel, city2Panel, mapPanel, noGold;

    public Text goldText;

    public Toggle city1Toggle, city2Toggle;
    public Button city1TravelButton, city2TravelButton;

    public float showMessageCoolDownTimer = 2f;

    private TravelNPC travelNpcScript;
    private TravelNPC2 travelNpcScript2;
    private PlayerGold playerGold;

    private Transform playerPos, TravelNPC1Pos, TravelNPC2Pos;

    private int travelCost;

    private float showMessageTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        travelNpcScript = FindObjectOfType<TravelNPC>();
        travelNpcScript2 = FindObjectOfType<TravelNPC2>();
        playerGold = FindObjectOfType<PlayerGold>();
        TravelNPC1Pos = GameObject.FindGameObjectWithTag("Travel NPC").GetComponent<Transform>();
        TravelNPC2Pos = GameObject.FindGameObjectWithTag("Travel NPC 2").GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        travelCost = 20;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "" + playerGold.gold;

        city2TravelButton.onClick.AddListener(PlayerTravelToCity2);
        city1TravelButton.onClick.AddListener(PlayerTravelToCity1);
        MessageTimer();
    }

    private void PlayerTravelToCity1()
    {
        if (playerGold.gold >= travelCost && travelNpcScript2.travelCity2Selected == true)
        {
            playerPos.position = new Vector2(TravelNPC1Pos.position.x + 2, TravelNPC1Pos.position.y);
            playerGold.gold -= travelCost;

            travelNpcScript2.travelCity2Selected = false;
            travelNpcScript2.accepted = false;
            city1Toggle.isOn = false;
            city2Toggle.isOn = false;

            city1Panel.gameObject.SetActive(false);
            city2Panel.gameObject.SetActive(false);
            mapPanel.gameObject.SetActive(false);
        }

        else if (playerGold.gold < travelCost && showMessageTimer > 0)
        {
            noGold.gameObject.SetActive(true);
        }

        showMessageTimer = showMessageCoolDownTimer;
    }

    private void PlayerTravelToCity2()
    {
        if (playerGold.gold >= travelCost && travelNpcScript.travelCity1Selected == true)
        {
            playerPos.position = new Vector2(TravelNPC2Pos.position.x + 2, TravelNPC2Pos.position.y);
            playerGold.gold -= travelCost;

            travelNpcScript.travelCity1Selected = false;
            travelNpcScript.accepted = false;
            city1Toggle.isOn = false;
            city2Toggle.isOn = false;

            city1Panel.gameObject.SetActive(false);
            city2Panel.gameObject.SetActive(false);
            mapPanel.gameObject.SetActive(false);
        }

        else if (playerGold.gold < travelCost && showMessageTimer > 0)
        {
            noGold.gameObject.SetActive(true);
        }

        showMessageTimer = showMessageCoolDownTimer;
    }

    private void MessageTimer()
    {
        if (showMessageTimer <= 0)
        {
            noGold.gameObject.SetActive(false);
        }
        else
        {
            showMessageTimer -= Time.deltaTime;
        }
    }

}
