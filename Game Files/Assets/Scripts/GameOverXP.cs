using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverXP : MonoBehaviour
{
    //Sets the gold display at the end of the round to the current total
    private void Awake()
    {
        GameObject GM = GameObject.Find("_GM");
        GetComponent<Text>().text = GM.GetComponent<GameMaster>().xp.ToString();
    }
}