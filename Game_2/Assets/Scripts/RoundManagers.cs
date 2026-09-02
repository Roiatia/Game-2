using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField] private float RoundDuration = 25f;
    [SerializeField] private RoundChest roundChest;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerStats playerStats;

    private int currentRound = 1;
    private float roundTimer;
    private bool isRoundActive;
    private bool isGameOver;



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
        isRoundActive = true;

        Debug.Log("Round " + currentRound + " started. Duration: " + RoundDuration + " seconds.");

        enemySpawner.SpawnEnemy(currentRound);
    }
    private void EndRound()
    {
        isRoundActive = false;
        Debug.Log("Round " + currentRound + " ended.");
        roundChest.SetAvailable();
    }

    public void OnDestroy()
    {
        playerStats.PlayerDied -= OnPlayerDied;
    }


private void OnPlayerDied()
    {
        isGameOver = true;
        isRoundActive = false;
        Debug.Log("Game Over! Player has died.");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     playerStats.PlayerDied += OnPlayerDied;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRoundActive)
        {
            return;
        }

        roundTimer -= Time.deltaTime;

        if(roundTimer <= 0)
        {
            EndRound();
        }
    }


 
}
