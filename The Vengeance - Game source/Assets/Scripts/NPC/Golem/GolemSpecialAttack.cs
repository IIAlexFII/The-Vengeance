using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSpecialAttack : MonoBehaviour //in the golem special attack the golem will invoque orcs every time he loses 100 of life
{
    //Game Objects
    public GameObject orcPrefab;

    //Files
    private GolemLife golemLife;

    //Bools
    public bool specialAttackActive = false;

    //Floats
    public float waveTimer = 0;

    //Arrays
    private Vector3[] orcPosition;

    void Start()
    {
        //Files
        golemLife = FindObjectOfType<GolemLife>();

        //Array
        orcPosition = new[] { new Vector3(-199.13f, -98.2f), new Vector3(-199.13f, -100.26f), new Vector3(-199.13f, -102.28f), new Vector3(-199.13f, -104.3f) }; //positions where the orcs will appear
    }

    void Update()
    {
        if (golemLife.life <= 400 && golemLife.life > 300 && specialAttackActive == false) // invoques 2 orcs when golem life is < or = to 400 but > than 300
        {
            GameObject orc1 = Instantiate(orcPrefab, orcPosition[0], Quaternion.identity);
            GameObject orc2 = Instantiate(orcPrefab, orcPosition[1], Quaternion.identity);
            specialAttackActive = true;

        }
        else if(golemLife.life <= 300 && golemLife.life > 200 && specialAttackActive == true) // invoques 4 orcs when golem life is < or = to 300 but > than 200
        {

            GameObject orc1 = Instantiate(orcPrefab, orcPosition[0], Quaternion.identity);
            GameObject orc2 = Instantiate(orcPrefab, orcPosition[1], Quaternion.identity);
            GameObject orc3 = Instantiate(orcPrefab, orcPosition[2], Quaternion.identity);
            GameObject orc4 = Instantiate(orcPrefab, orcPosition[3], Quaternion.identity);
            specialAttackActive = false;
        }
        else if (golemLife.life <= 200 && golemLife.life > 100 && specialAttackActive == false) // invoques 4 orcs when golem life is < or = to 200 but > than 100
        {

            GameObject orc1 = Instantiate(orcPrefab, orcPosition[0], Quaternion.identity);
            GameObject orc2 = Instantiate(orcPrefab, orcPosition[1], Quaternion.identity);
            GameObject orc3 = Instantiate(orcPrefab, orcPosition[2], Quaternion.identity);
            GameObject orc4 = Instantiate(orcPrefab, orcPosition[3], Quaternion.identity);

            specialAttackActive = true;
            waveTimer += Time.deltaTime; // will add to the waveTimer to invoque more orcs
            if (waveTimer >= 2 && specialAttackActive == true) // invoques 4 more orcs when waveTimer is >= to 2 and specialAttack Active is true (this part doesn't envolve the golem life)
            {
                GameObject orc5 = Instantiate(orcPrefab, orcPosition[0], Quaternion.identity);
                GameObject orc6 = Instantiate(orcPrefab, orcPosition[1], Quaternion.identity);
                GameObject orc7 = Instantiate(orcPrefab, orcPosition[2], Quaternion.identity);
                GameObject orc8 = Instantiate(orcPrefab, orcPosition[3], Quaternion.identity);
                specialAttackActive = false;
            }
        }
    }
}
