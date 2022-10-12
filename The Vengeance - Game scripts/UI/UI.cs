using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject talkButtonPrefab;

    private TalkQuest talkQuest;
    private TravelNPC NPCtravel;
    private TravelNPC2 NPCtravel2;
    private RangedArea rangedArea;

    private GameObject keyButton;
    private GameObject keyButton2;
    private GameObject keyButtonQuest;

    private bool talkButtonDisplayed;
    private bool talkButtonDisplayed2;
    private bool talkButtonQuestDisplayed;

    private void Start()
    {
        talkButtonDisplayed = false;
        talkButtonDisplayed2 = false;
        talkButtonQuestDisplayed = false;
        NPCtravel = FindObjectOfType<TravelNPC>();
        NPCtravel2 = FindObjectOfType<TravelNPC2>();
        rangedArea = FindObjectOfType<RangedArea>();
        talkQuest = FindObjectOfType<TalkQuest>();
    }

    //This code needs to be optimazed for the 3rd delivery
    //One function for all NPC'S
    private void NPCTalkButtonDisplay()
    {
        //TRAVEL NPC
        if (NPCtravel.playerInRange == true && NPCtravel.NPCchatEnabled == false && talkButtonDisplayed == false)
        {
            keyButton = Instantiate(talkButtonPrefab, transform);
            keyButton.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            talkButtonDisplayed = true;
        }

        if ((NPCtravel.playerInRange == false) || (NPCtravel.NPCchatEnabled == true || NPCtravel.accepted == true))
        {
            Object.Destroy(keyButton);
            talkButtonDisplayed = false;
        }
    }

    private void NPCTalkButtonDisplay2()
    {
        if (rangedArea.playerInRange == true && talkQuest.NPCchatEnabled == false && talkButtonQuestDisplayed == false)
        {
            keyButtonQuest = Instantiate(talkButtonPrefab, transform);
            keyButtonQuest.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            talkButtonQuestDisplayed = true;
        }

        if ((rangedArea.playerInRange == false) || (talkQuest.NPCchatEnabled == true))
        {
            Object.Destroy(keyButtonQuest);
            talkButtonQuestDisplayed = false;
        }
    }

    private void NPCTalkButtonDisplay3()
    {
        //TRAVEL NPC 2
        if (NPCtravel2.playerInRange == true && NPCtravel2.NPCchatEnabled == false && talkButtonDisplayed2 == false)
        {
            keyButton2 = Instantiate(talkButtonPrefab, transform);
            keyButton2.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            talkButtonDisplayed2 = true;
        }

        if ((NPCtravel2.playerInRange == false) || (NPCtravel2.NPCchatEnabled == true || NPCtravel2.accepted == true))
        {
            Object.Destroy(keyButton2);
            talkButtonDisplayed2 = false;
        }

    }


    // Update is called once per frame
    private void Update()
    {
        NPCTalkButtonDisplay();
        NPCTalkButtonDisplay2();
        NPCTalkButtonDisplay3();
    }
}
