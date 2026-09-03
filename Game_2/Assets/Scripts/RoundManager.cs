using UnityEngine;
using System;

public class RoundManager : MonoBehaviour
{

    public event Action<int> RoundChanged;
    public event Action<int> TimerChanged;

    public event Action GameWon;

    [SerializeField] private float RoundDuration = 25f;
    [SerializeField] private int MaxRounds = 5; 
    [SerializeField] private RoundChest roundChest;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerStats playerStats;

    private int currentRound = 0;
    private int enemiesAlive;
    private float roundTimer;
    private int lastTimerValue;
    private bool isRoundActive;
    private bool isGameOver;



    public int GetCurrentRound()
    {
        return currentRound;
    }


    public int GetCurrentTimer()
    {

        if(!isRoundActive)
        {
            return Mathf.CeilToInt(RoundDuration);
        }


        return Mathf.CeilToInt(roundTimer);
    }



    public void StartRound()
    {
        if (isGameOver)
        {
            Debug.Log("Game is over. Cannot start a new round.");
            return;
        }

        if(isRoundActive)
        {
            Debug.Log("Round is already active");
            return;

        }

        currentRound++;
        roundTimer = RoundDuration;
        lastTimerValue = Mathf.CeilToInt(roundTimer);
        isRoundActive = true;

        RoundChanged?.Invoke(currentRound);
        TimerChanged?.Invoke(lastTimerValue);



        Debug.Log("Round " + currentRound + " started. Duration: " + RoundDuration + " seconds.");

        enemiesAlive = enemySpawner.SpawnEnemy(currentRound);
    }



    private void EndRound()
    {
        isRoundActive = false;
        Debug.Log("Round " + currentRound + " ended.");

        if (currentRound >= MaxRounds)
        {
        
            Debug.Log("YOU WIN !!");
            isGameOver = true;
            GameWon?.Invoke();
            return;


        }


        roundChest.SetAvailable();
    }


    private void OnDestroy()
    {
        if (playerStats != null)
        {
            playerStats.PlayerDied -= OnPlayerDied;
        }
        EnemyHealth.EnemyDied -= OnEnemyDied;
    }




    private void OnPlayerDied()
    {
        isGameOver = true;
        isRoundActive = false;
        Debug.Log("Game Over! Player has died.");
    }





    private void OnEnemyDied()
    {
        if (!isRoundActive)
        {
            return;
        }

        enemiesAlive--;


        Debug.Log("Enemies Left : " + enemiesAlive);

        if (enemiesAlive <= 0) 
        {
            EndRound();
        }

    }


 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     playerStats.PlayerDied += OnPlayerDied;

        EnemyHealth.EnemyDied += OnEnemyDied;
    }






    // Update is called once per frame
    void Update()
    {
        if (!isRoundActive)
        {
            return;
        }

        roundTimer -= Time.deltaTime;

        int timerValue = Mathf.CeilToInt(roundTimer);

        if (timerValue != lastTimerValue)
        {
            lastTimerValue = timerValue;
            TimerChanged?.Invoke(timerValue);
        }

        if (roundTimer <= 0)
        {
            EndRound();
        }
    }



    }
