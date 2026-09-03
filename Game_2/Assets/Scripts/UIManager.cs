using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class UIManager : MonoBehaviour
{

    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private RoundManager roundManager;

    [SerializeField] private TMP_Text healthText;

    [SerializeField] private TMP_Text roundText;

    [SerializeField] private TMP_Text timerText;

    [SerializeField] private TMP_Text gameMessageText;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
              Time.timeScale = 1f;

            healthText.text = "Health: " + playerStats.GetHealth();
            roundText.text = "Round: " + roundManager.GetCurrentRound();
            timerText.text = "Time left: " + roundManager.GetCurrentTimer();

            playerStats.PlayerHealthChange += OnHealthChange;
            playerStats.PlayerDied += OnPlayerDied;

            roundManager.RoundChanged += OnRoundChanged;
            roundManager.TimerChanged += OnTimerChanged;
            roundManager.GameWon += OnGameWon;

        gameMessageText.gameObject.SetActive(false);
        
    }



    private void OnHealthChange(int health)
    {
        healthText.text = "Health: " + health;
    }


    private void OnDestroy()
    {
        if (playerStats != null)
        {
            playerStats.PlayerHealthChange -= OnHealthChange;
            playerStats.PlayerDied -= OnPlayerDied;
        }

        if (roundManager != null)
        {
            roundManager.RoundChanged -= OnRoundChanged;
            roundManager.TimerChanged -= OnTimerChanged;
            roundManager.GameWon -= OnGameWon;
        }
    }

    private void OnRoundChanged(int round)
    {
        roundText.text = "Round: " + round;
    }

    private void OnTimerChanged(int timeLeft)
    {
        timerText.text = "Time left: " + timeLeft;
    }



    private void OnPlayerDied()
    {
        gameMessageText.text = "GAME OVER";
        gameMessageText.gameObject.SetActive(true);

        Time.timeScale = 0f; // Pause the game
    }



    private void OnGameWon()
    {
        gameMessageText.text = "YOU WIN !!";
        gameMessageText.gameObject.SetActive(true);

        Time.timeScale = 0f; 
    }
}
