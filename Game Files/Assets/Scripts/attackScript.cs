using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script contols how the game detects enemies that have been hit and then deals damage and knocks them back.
public class attackScript : MonoBehaviour
{
    public float knockback;

    //This method is called anytime a collider2D enters the collider2D that this script is attached to.
    private void OnTriggerStay2D(Collider2D other)
    {
        //Determines the type of enemy that is in attack range
        if (other.tag == "slime" && Input.GetButton("Jump"))
        {
            //Deals damage to enemy
            other.GetComponent<Slime>().DamageSlime(Player.Damage);
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            //Knock the enemy back
            if(enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
            }
        }
        if (other.tag == "wraith" && Input.GetButton("Jump"))
        {
            other.GetComponent<Wraith>().DamageWraith(Player.Damage);
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
            }
        }
        if (other.tag == "zombie" && Input.GetButton("Jump"))
        {
            other.GetComponent<Zombie>().DamageZombie(Player.Damage);
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
            }
        }
        if (other.tag == "goblin" && Input.GetButton("Jump"))
        {
            other.GetComponent<Goblin>().DamageGoblin(Player.Damage);
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
            }
        }
        if (other.tag == "skeleton" && Input.GetButton("Jump"))
        {
            other.GetComponent<Skeleton>().DamageSkeleton(Player.Damage);
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
            }
        }
    }
}
