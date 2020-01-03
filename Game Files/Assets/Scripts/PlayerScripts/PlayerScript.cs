using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script tracks player movement and controls.
public class PlayerScript : MonoBehaviour
{
    public Vector2 speed = new Vector2(50, 50);
    public Animator animator;
    public Rigidbody2D rb;

    private bool attack;

    [SerializeField]
    public AudioSource attackAudio;

    //This checks if the player is pressing the movement keys and moves the player in the correct direction.
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        animator.SetFloat("speed", Mathf.Abs(inputX) + Mathf.Abs(inputY));

        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        Vector3 characterScale = transform.localScale;
        if (inputX < 0)
        {
            characterScale.x = -1;
        }

        if (inputX > 0)
        {
            characterScale.x = 1;
        }

        transform.localScale = characterScale;

        rb.velocity = new Vector2(movement.x, movement.y);

        InputHandler();
        AttackAnim();
    }

    //Plays attack audio if attack button pressed
    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
            attackAudio.Play();
        }
    }

    //Plays attack animation if attack button pressed
    private void AttackAnim()
    {
        if (attack)
        {
            animator.SetTrigger("attack");
            attack = false;
        }
    }
}
