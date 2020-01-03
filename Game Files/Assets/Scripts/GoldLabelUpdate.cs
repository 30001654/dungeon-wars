using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldLabelUpdate : MonoBehaviour
{
    private GameObject GM;
    private void Awake()
    {
        GM = GameObject.Find("_GM");
    }

    //Updates the in-game gold counter
    private void LateUpdate()
    {
        GetComponent<Text>().text = GM.GetComponent<GameMaster>().gold.ToString();
    }
}