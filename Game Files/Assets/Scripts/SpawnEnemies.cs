using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls each rounds monster spawns.
public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    private System.Random rand = new System.Random();
    public int entityID = 0;
    public int monsterCount;

    private void Start()
    {
        StartCoroutine(SpawnRound());
    }

    IEnumerator SpawnRound()
    {
        int spawnNumber = rand.Next(5, 10); //Generates a random number between 5 and 10 to be the number of enemies to spawn that round.
        GameObject GM = GameObject.Find("_GM");
        GM.GetComponent<GameMaster>().monsterNumbers = spawnNumber; //Sends the number of spawned monsters to the GameMaster object to keep track of them.
        //Spawn in a monster every 5 seconds until the number defined before has been reached
        for (int i = 0; i < spawnNumber; i++)
        {
            SpawnMonster();
            yield return new WaitForSeconds(5);
        }
    }

    //Assigns each monster a index value and randomly selects one of them to be instantiated.
    public void SpawnMonster()
    {
        int monsterID = rand.Next(enemies.Length);
        int spawnLocation = rand.Next(4);
        GameObject e = Instantiate(enemies[monsterID]) as GameObject;
        e.name += entityID;
        entityID++;
    }
}
