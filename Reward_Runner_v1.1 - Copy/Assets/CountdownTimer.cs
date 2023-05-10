using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 10;
    public Text countdownText;
    public GameObject objectToActivate;
    public AudioSource timerWarning;


    bool timerStarted = false;

    void Update()
    {
        if (objectToActivate.activeSelf && timerStarted)
        {
            timeRemaining = 10;
            countdownText.text = "Time Remaining: " + Mathf.Round(timeRemaining).ToString();
            timerStarted = false;
        }

        if (!objectToActivate.activeSelf && !timerStarted)
        {
            timerStarted = true;
            timerWarning.Play();
        }

        if (timerStarted && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            countdownText.text = "Time left: " + Mathf.Round(timeRemaining).ToString();

        }
        else if (timerStarted && timeRemaining <= 0)
        {
            //timerWarning.Play();
            countdownText.text = "Time's up!";
            //objectToActivate.SetActive(true);
        }
    }
}
