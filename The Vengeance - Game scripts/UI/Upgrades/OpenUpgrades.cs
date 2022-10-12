using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OpenUpgrades : MonoBehaviour
{
    private BossSlimeMovement bossSlimeMovement;
    private PlayerAttackandBlock attackandBlock;
    private PlayerController playerController;
    private QuestNPCMovement questNPCMovement;

    public GameObject upgradesPanel;
    public GameObject attackUpgradesPanel;
    public GameObject defenseUpgradesPanel;
    public GameObject playerStatsInfo;
    public GameObject openUpgrades;

    public bool panelActive = false;
    public bool panelAttackActive = false;
    public bool panelDefenseActive = false;

    public Button exitUpgradesButton;
    public Button attackUpgradesButton;
    public Button defenseUpgradesButton;

    // Start is called before the first frame update
    void Start()
    {
        bossSlimeMovement = FindObjectOfType<BossSlimeMovement>();
        attackandBlock = FindObjectOfType<PlayerAttackandBlock>();
        questNPCMovement = FindObjectOfType<QuestNPCMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        OpenUpgradesPanel();
        ShowUpgradesButton();

    }

    private void OpenUpgradesPanel()
    {
        if (Input.GetKeyDown(KeyCode.U) && panelActive == false)
        {

            upgradesPanel.gameObject.SetActive(true);
            playerStatsInfo.gameObject.SetActive(true);
            openUpgrades.gameObject.SetActive(false);
            panelActive = true;
            bossSlimeMovement.enabled = false;
            playerController.enabled = false;
            questNPCMovement.enabled = false;
        }
    }
    public void CloseUpgradesPanel()
    {
        upgradesPanel.gameObject.SetActive(false);
        attackUpgradesPanel.gameObject.SetActive(false);
        defenseUpgradesPanel.gameObject.SetActive(false);
        playerStatsInfo.gameObject.SetActive(false);
        openUpgrades.gameObject.SetActive(true);

        panelActive = false;
        panelAttackActive = false;
        panelDefenseActive = false;

        bossSlimeMovement.enabled = true;
        playerController.enabled = true;
        questNPCMovement.enabled = true;
    }

    public void OpenAttackUpgradesPanel()
    {
        if (panelActive == true)
        {

            if (panelDefenseActive == true)
            {
                defenseUpgradesPanel.gameObject.SetActive(false);
                panelDefenseActive = false;
                attackUpgradesPanel.gameObject.SetActive(true);
                panelAttackActive = true;
            }
            else
            {
                attackUpgradesPanel.gameObject.SetActive(true);
                panelAttackActive = true;
            }
        }
    }

    public void OpenDefenseUpgradesPanel()
    {
        if (panelActive == true)
        {
            if (panelAttackActive == true)
            {
                attackUpgradesPanel.gameObject.SetActive(false);
                panelAttackActive = false;
                defenseUpgradesPanel.gameObject.SetActive(true);
                panelDefenseActive = true;
            }
            else
            {
                defenseUpgradesPanel.gameObject.SetActive(true);
                panelDefenseActive = true;
            }
        }
    }

    public void ShowUpgradesButton()
    {
        if (panelActive == true)
        {

            exitUpgradesButton = GetComponentInChildren<Button>();
            exitUpgradesButton.onClick.AddListener(CloseUpgradesPanel);

            attackUpgradesButton.onClick.AddListener(OpenAttackUpgradesPanel);
            defenseUpgradesButton.onClick.AddListener(OpenDefenseUpgradesPanel);
        }
    }

}
