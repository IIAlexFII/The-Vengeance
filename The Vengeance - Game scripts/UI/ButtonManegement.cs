using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonManegement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = Color.red; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.black;
    }

}
