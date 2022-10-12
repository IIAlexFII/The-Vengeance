using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkQuest : MonoBehaviour
{
    public GameObject chatPrefab;
    public GameObject chatBoxPrefab;
    public GameObject buttonPrefab;

    private RangedArea rangedArea;

    private RectTransform WorldcanvasTransform;

    private GameObject chat;
    private GameObject chatBox;
    private GameObject button;
    private GameObject button2;

    private bool declined;
    [HideInInspector] public bool accepted;

    [HideInInspector] public bool NPCchatEnabled;

    private string[] npcPhrases;
    private int npcPhrasesIndex;

    public bool questFinished;
    public bool reward;

    public bool lastText;
    public bool playerMove;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        rangedArea = FindObjectOfType<RangedArea>();
        WorldcanvasTransform = GameObject.FindGameObjectWithTag("WorldCanvas").GetComponent<RectTransform>();

        npcPhrasesIndex = 0;

        lastText = false;

        questFinished = false;
        reward = false;
        NPCchatEnabled = false;
        accepted = false;
        declined = false;
        playerMove = true;

    }

    private void chatTalk()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if ((Input.GetKeyDown(KeyCode.E)) && (rangedArea.playerInRange == true) && (NPCchatEnabled == false)) //see if the player is in the area of the npc and if the player clicked E
        {
            playerMove = false;

            //instatiate objects (box, chat and butn)
            chatBox = Instantiate(chatBoxPrefab, new Vector3(pos.x, pos.y + 2, pos.z), Quaternion.identity, WorldcanvasTransform);
            chat = Instantiate(chatPrefab, new Vector3(pos.x, pos.y + 2.3f, pos.z), Quaternion.identity, WorldcanvasTransform);
            button = Instantiate(buttonPrefab, new Vector3(pos.x + 2, pos.y + 1.5f, pos.z), Quaternion.identity, WorldcanvasTransform);

            if (accepted == false)
            {
                npcPhrases = new string[] { "Travelling to the next village is very dangerous!",
                "I will reward who is able to clean its path",
                "Are you the one?"};
            }
            else if (questFinished == false)
            {
                npcPhrases = new string[] { "You haven't finished yet", "Please hurry!" };

            }

            if (questFinished == true && lastText == true)
            {
                npcPhrases = new string[] { "Thank you for your help!" };
            }
            else if (questFinished == true)
            {
                npcPhrases = new string[] { "Good job, thank you for your help!", "Here is your reward" };
                reward = true;
                lastText = true;
            }
            
            chat.GetComponent<TypeWriting>().textToWrite = npcPhrases[npcPhrasesIndex]; //type write effect

            button.GetComponentInChildren<Text>().text = "-->";

            NPCchatEnabled = true;
            //Cursor.visible = true;

            button.GetComponent<Button>().onClick.AddListener(TestArray);
        }

        if ((rangedArea.playerInRange == false) || (Input.GetKeyDown(KeyCode.E) && NPCchatEnabled == true) || declined == true || accepted == true)
        {
            NPCchatEnabled = false;
            
            declined = false;
            
        }

        if(rangedArea.playerInRange == false) //player out of the npc area
        {
            Object.Destroy(chat);
            Object.Destroy(chatBox);
            Object.Destroy(button);
            Object.Destroy(button2);
            npcPhrasesIndex = 0;
        }
    }

    private void TestArray()
    {
        if (npcPhrasesIndex < npcPhrases.Length - 1)
        {
            Destroy(chat);
            chat = Instantiate(chatPrefab, new Vector3(pos.x, pos.y + 2.3f, pos.z), Quaternion.identity, WorldcanvasTransform);

            npcPhrasesIndex++;
            chat.GetComponent<TypeWriting>().textToWrite = npcPhrases[npcPhrasesIndex];
            chat.GetComponent<Text>().text = npcPhrases[npcPhrasesIndex];
        }

        if (npcPhrasesIndex == npcPhrases.Length - 1)
        {
            Destroy(button);
            button = Instantiate(buttonPrefab, new Vector3(pos.x + 2, pos.y + 1.5f, pos.z), Quaternion.identity, WorldcanvasTransform);
            button2 = Instantiate(buttonPrefab, new Vector3(pos.x - 2, pos.y + 1.5f, pos.z), Quaternion.identity, WorldcanvasTransform);

            button.GetComponent<Button>().onClick.AddListener(AcceptQuest);
            button2.GetComponent<Button>().onClick.AddListener(DeclineQuest);

            button.GetComponentInChildren<Text>().text = "Yes";
            button2.GetComponentInChildren<Text>().text = "No";
        }
    }
    private void AcceptQuest()
    {
        playerMove = true;
        accepted = true;
        Object.Destroy(chat);
        Object.Destroy(chatBox);
        Object.Destroy(button);
        Object.Destroy(button2);
        npcPhrasesIndex = 0;
    }

    private void DeclineQuest()
    {
        playerMove = true;
        declined = true;
        Object.Destroy(chat);
        Object.Destroy(chatBox);
        Object.Destroy(button);
        Object.Destroy(button2);
        npcPhrasesIndex = 0;
    }

    void Update()
    {
        chatTalk();
    }
}