using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is the script that tracks golbal variables that are needed in different scenes.
public class GameMaster : MonoBehaviour
{
    public int gold;
    public int xp;
    public bool win;
    public GameObject sceneManager;
    public int monsterNumbers;

    static GameMaster instance = null;

    //Sets the GameMaster object to never be destroyed.
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    //Ends game if no monsters are remaining
    private void LateUpdate()
    {
        if (monsterNumbers == 0)
        {
            sceneManager.GetComponent<LoadScene>().SceneLoader(2);
        }
    }

    //Adds gold to player
    public void addGold(int increaseGold)
    {
        gold += increaseGold;
    }

    //Adds xp to player
    public void addXP(int increaseXP)
    {
        xp += increaseXP;
    }
}