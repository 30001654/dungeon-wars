using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wraith : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    public int damage = 1;
    public int currentHealth;

    //Resets health on new game
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    //Deals damage to the wraith and plays their damaged animation
    public void DamageWraith(int damage)
    {
        currentHealth -= damage;
        GetComponent<Animator>().SetTrigger("damaged");
        //If the wraith dies add gold and xp to the player, reduce the count of monsters by 1 and then destroy this object.
        if (currentHealth <= 0)
        {
            GameObject GM = GameObject.Find("_GM");
            GM.GetComponent<GameMaster>().addGold(50);
            GM.GetComponent<GameMaster>().addXP(200);
            GM.GetComponent<GameMaster>().monsterNumbers--;
            Destroy(gameObject);
        }
    }

    //Deals damage to the player if the players collider2D touches the collider2D this script is attached to
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().DamagePlayer(damage);
        }
    }
}