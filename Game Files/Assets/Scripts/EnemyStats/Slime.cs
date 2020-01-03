using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int maxHealth = 100;
    public int damage = 1;
    public int currentHealth;

    //Resets health on new game
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    //Deals damage to the slime and plays their damaged animation
    public void DamageSlime(int damage)
    {
        currentHealth -= damage;
        GetComponent<Animator>().SetTrigger("damaged");
        //If the slime dies add gold and xp to the player, reduce the count of monsters by 1, plays a death animation and then destroy this object.
        if (currentHealth <= 0)
        {
            GetComponent<Animator>().SetTrigger("isDead");
            StartCoroutine(WaitForDeath());
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(0.4f);
        GameObject GM = GameObject.Find("_GM");
        GM.GetComponent<GameMaster>().addGold(10);
        GM.GetComponent<GameMaster>().addXP(50);
        GM.GetComponent<GameMaster>().monsterNumbers--;
        Destroy(gameObject);
    }

    //Deals damage to the player if the players collider2D touches the collider2D this script is attached to
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().DamagePlayer(damage);
        }
    }
}