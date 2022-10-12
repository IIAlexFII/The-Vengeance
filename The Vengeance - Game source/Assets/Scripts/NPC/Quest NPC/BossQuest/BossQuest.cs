using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossQuest : MonoBehaviour
{
    Text newObjectiveText;
    Text newRewardText;

    public GameObject questUI;
    public GameObject questObjective;
    public GameObject questReward;

    private TalkBossQuest talkBossQuest;
    private GolemLife golemLife;
    private PlayerGold playerGold;

    private bool questDestroy;

    private void Start()
    {
        newObjectiveText = questObjective.GetComponent<Text>();
        newRewardText = questReward.GetComponent<Text>();
        talkBossQuest = FindObjectOfType<TalkBossQuest>();
        golemLife = FindObjectOfType<GolemLife>();
        playerGold = FindObjectOfType<PlayerGold>();
        questDestroy = false;
    }
    private void Mission()
    {
        if (talkBossQuest.accepted == true && questDestroy == false)
        {
            questUI.SetActive(true);
            newObjectiveText.text = "Kill the Golem";
            newRewardText.text = "Reward: 2000 coins";

            if (golemLife.life <= 0)
            {
                talkBossQuest.questFinished = true;
            }
        }

        if (talkBossQuest.reward == true)
        {
            questUI.SetActive(false);
            playerGold.gold += 2000;
            talkBossQuest.reward = false;
            questDestroy = true;
        }
    }

    private void Update()
    {
        Mission();
    }
}
