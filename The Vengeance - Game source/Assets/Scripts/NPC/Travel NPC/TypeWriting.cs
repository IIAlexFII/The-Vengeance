using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriting : MonoBehaviour
{
    private Text uiText;

    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    [HideInInspector]public string textToWrite;

    private void Start()
    {
        timePerCharacter = 0.04f;
        characterIndex = 0;
        uiText = GetComponent<Text>();
    }

    private void npcChat()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Display the next character
                timer += timePerCharacter;
                characterIndex++;
                uiText.text = textToWrite.Substring(0, characterIndex);

                if (characterIndex >= textToWrite.Length)
                {
                    //Entire text displayed
                    uiText = null;
                    return;
                }
            }
        }
    }

    private void Update()
    {
        npcChat();
    }
}
