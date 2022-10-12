using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D cursorTexture;

    private OpenUpgrades openUpgrades;
    private PauseMenu pauseMenu;

    private TalkQuest talkQuest;
    private TalkBossQuest talkBossQuest;

    private bool cursorActive;
    // Start is called before the first frame update
    void Start()
    {
        /*openUpgrades = FindObjectOfType<OpenUpgrades>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        talkQuest = FindObjectOfType<TalkQuest>();
        talkBossQuest = FindObjectOfType<TalkBossQuest>();*/
        Cursor.visible = true;
        /*cursorActive = false;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);*/
    }
    /*private void Update()
    {
        if (openUpgrades.panelActive == true && cursorActive == false)
        {
            Cursor.visible = true;
            cursorActive = true;
        }else if (pauseMenu.gamePaused == true && cursorActive == false)
        {
            Cursor.visible = true;
            cursorActive = true;
        }
        else if (talkQuest.playerMove == false && cursorActive == false)
        {
            Cursor.visible = true;
            cursorActive = true;
        }
        else if (talkBossQuest.playerMove == false && cursorActive == false)
        {
            Cursor.visible = true;
            cursorActive = true;
        }
        else
        {
            Cursor.visible = false;
            cursorActive = false;
        }
    }*/
}
