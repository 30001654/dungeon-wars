using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//This script tracks the amount of the health bar that is filled.
public class HealthbarScript : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

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
