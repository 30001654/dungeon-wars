using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public static int Damage = 5;

    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;
    [SerializeField]
    public AudioSource oofAudio;
    [SerializeField]
    public AudioSource gameOverAudio;

    public GameObject sceneManager;

    //Deals damage to the player
    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        float currentHealthPct = (float)currentHealth / (float)maxHealth;
        ChangeToPct(currentHealthPct);
        GetComponent<Animator>().SetTrigger("damaged"); //Plays the damaged animation
        oofAudio.Play(); //Plays the damaged audio
        //If the players health reaches 0 or lower the game will play the game over audio, hide the players sprite.
        //It then waits 2 seconds so that the game over audio can finish playing, tells the GameMaster object the round was a loss and then loads the game over scene.
        if (currentHealth <= 0)
        {
            StartCoroutine(WaitForDeath());
            gameOverAudio.Play();
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("_GM").GetComponent<GameMaster>().win = false;
        sceneManager.GetComponent<LoadScene>().SceneLoader(2);
    }

    //Reset health on new round.
    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
        }

        foregroundImage.fillAmount = pct;
    }
}
