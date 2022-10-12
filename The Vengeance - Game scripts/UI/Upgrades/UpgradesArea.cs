using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesArea : MonoBehaviour
{
    public GameObject openUpgrades;

    [HideInInspector] public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = true;
            openUpgrades.gameObject.SetActive(true);
}
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInRange = false;
            openUpgrades.gameObject.SetActive(false);

        }
    }
}
