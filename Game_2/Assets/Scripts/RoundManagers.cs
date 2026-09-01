using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField] private float RoundDuration = 25f;

    private int currentRound = 1;
    private float roundTimer;
    private bool isRoundActive;


    public void StartRound()
    {
        if(isRoundActive)
        {
            Debug.Log("Round is already active");
            return;

        }

        currentRound++;
        roundTimer = RoundDuration;
        isRoundActive = true;

        Debug.Log("Round " + currentRound + " started. Duration: " + RoundDuration + " seconds.");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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


    private void EndRound()
    {
        isRoundActive = false;
        Debug.Log("Round " + currentRound + " ended.");
    }
}
