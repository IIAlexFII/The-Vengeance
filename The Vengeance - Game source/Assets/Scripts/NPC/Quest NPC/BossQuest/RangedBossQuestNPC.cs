using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBossQuestNPC : MonoBehaviour
{
    [HideInInspector] public bool playerInRange;
    private PlayerController playerController;

    private void Start()
    {
        playerInRange = false;
        playerController = FindObjectOfType<PlayerController>();
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
            playerController.normalAttack = true;
        }
    }
}
