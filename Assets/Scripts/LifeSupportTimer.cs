using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro; // Make sure to include this for TextMeshPro components


public class LifeSupportTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public TextMeshProUGUI timerText;
    private float timeRemaining = 60f; // 1 minute
    private bool timerIsRunning = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            // Run Diaglogue
            // Send enemies towards life support area
            // Tell player they have to lock/electrify the door
            // Good luck, air begins reaching critical levels, start timer
            StartTimer();
        }
    }

    private void StartTimer()
    {
        if (!timerIsRunning)
        {
            timerIsRunning = true;
            timeRemaining = 60f; 
            UpdateTimerText();
            StartCoroutine(TimerCoroutine());
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1); // Wait for 1 second
            timeRemaining--;
            UpdateTimerText();
        }

        timerIsRunning = false;
        Debug.Log("Timer finished!");
        // If at any point, the timer runs out without the puzzle being completed, game over?
    }

    private void UpdateTimerText()
    {
        timerText.text = $"Time Remaining: {timeRemaining}";
    }
    */
}
