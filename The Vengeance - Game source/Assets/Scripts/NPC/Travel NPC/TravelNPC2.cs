using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelNPC2 : MonoBehaviour
{
    public GameObject chatPrefab;
    public GameObject chatBoxPrefab;
    public GameObject buttonPrefab;
    public GameObject mapPanel;

    private GameObject player;
    private GameObject canvas;
    private GameObject chat;
    private GameObject chatBox;
    private GameObject button;
    private GameObject button2;

    private Transform canvasTransform;
    private RectTransform UIcanvasTransform;
    private RectTransform chatboxSize;
    private RectTransform chatTextSize;

    private Button Button;

    private bool declined;
    private bool mapEnabled;

    [HideInInspector] public bool accepted;
    [HideInInspector] public bool playerInRange;
    [HideInInspector] public bool NPCchatEnabled;
    [HideInInspector] public bool travelCity2Selected;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas = GameObject.FindGameObjectWithTag("WorldCanvas");
        UIcanvasTransform = GameObject.FindGameObjectWithTag("UICanvas").GetComponent<RectTransform>();
        canvasTransform = canvas.GetComponent<Transform>();
        Button = FindObjectOfType<Button>();


        playerInRange = false;
        NPCchatEnabled = false;
        accepted = false;
        declined = false;
        mapEnabled = false;
        travelCity2Selected = false;
    }

    // Update is called once per frame
    private void Update()
    {
        chatTalk();
        mapPanelManage();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = false;

        }
    }

    private void chatTalk()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && (playerInRange == true) && (NPCchatEnabled == false))
        {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;

            chatBox = Instantiate(chatBoxPrefab, new Vector3(x, y + 2, z), Quaternion.identity, canvasTransform);
            chat = Instantiate(chatPrefab, new Vector3(x, y + 2.3f, z), Quaternion.identity, canvasTransform);
            button = Instantiate(buttonPrefab, new Vector3(x + 2, y + 1.5f, z), Quaternion.identity, canvasTransform);
            button2 = Instantiate(buttonPrefab, new Vector3(x - 2, y + 1.5f, z), Quaternion.identity, canvasTransform);

            chat.GetComponent<TypeWriting>().textToWrite = "Hello, do you wish to travel?";

            button.GetComponentInChildren<Text>().text = "Yes";
            button2.GetComponentInChildren<Text>().text = "No";

            chatboxSize = chatBox.GetComponent<RectTransform>();
            chatTextSize = chat.GetComponent<RectTransform>();

            chatboxSize.sizeDelta = new Vector2(170, 50);
            chatTextSize.sizeDelta = new Vector2(170, 30);

            chatboxSize.localScale = new Vector3(0.03f, 0.03f, 0.03f);
            chatTextSize.localScale = new Vector3(0.03f, 0.03f, 0.03f);

            NPCchatEnabled = true;
            //Cursor.visible = true;

            button.GetComponent<Button>().onClick.AddListener(AcceptTravel);
            button2.GetComponent<Button>().onClick.AddListener(DeclineTravel);
        }
        else if ((playerInRange == false) || (Input.GetKeyDown(KeyCode.E) && NPCchatEnabled == true) || declined == true || accepted == true)
        {
            Object.Destroy(chat);
            Object.Destroy(chatBox);
            Object.Destroy(button);
            Object.Destroy(button2);

            NPCchatEnabled = false;
            declined = false;
        }

    }

    private void AcceptTravel()
    {
        accepted = true;
    }

    private void DeclineTravel()
    {
        declined = true;
    }

    private void mapPanelManage()
    {
        if (accepted == true)
        {
            mapPanel.gameObject.SetActive(true);
            travelCity2Selected = true;
        }

    }

}
