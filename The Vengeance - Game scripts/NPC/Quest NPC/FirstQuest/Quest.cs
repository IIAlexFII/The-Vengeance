using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    Text newObjectiveText;
    Text newRewardText;

    public int orcCount = 0;
    public int skelCount = 0;

    public GameObject questUI;
    public GameObject questObjective;
    public GameObject questReward;

    private GameObject questUiInstance;

    private TalkQuest talkQuest;
    private PlayerGold playerGold;

    private bool questDestroy;

    private void Start()
    {
        newObjectiveText = questObjective.GetComponent<Text>();
        newRewardText = questReward.GetComponent<Text>();
        talkQuest = FindObjectOfType<TalkQuest>();
        playerGold = FindObjectOfType<PlayerGold>();

        questDestroy = false;
    }

    private void Mission() //instantiate the mission sqr
    {
        if (talkQuest.accepted == true && questDestroy == false)
        {
            questUI.SetActive(true);
            newObjectiveText.text = "Kill: " + orcCount + "/10 Orcs" + "\n" + "Kill: " + skelCount + "/10 Skeletons";
            newRewardText.text = "Reward: 500 coins";

            if (orcCount >= 1 && skelCount >= 0)
            {
                talkQuest.questFinished = true;

            }

        }

        if (talkQuest.reward == true)
        {
            questUI.SetActive(false);
            playerGold.gold += 500;
            talkQuest.reward = false;
            questDestroy = true;
        }
    }

    private void Update()
    {
        Mission();
    }
}
