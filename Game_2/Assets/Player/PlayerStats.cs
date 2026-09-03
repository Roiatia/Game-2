using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    public event Action PlayerDied;
    public event Action<int> PlayerHealthChange;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private int playerHealth = 50;

    private bool isDead;


    public int GetHealth()
    {
        return playerHealth;
    }



    public void ApplyBuff(BuffType buffType)
    {
        if(buffType == BuffType.Speed)
        {
            playerMovement.IncreaseSpeed();
            Debug.Log("Speed Buff Applied"); 
        } 
        else if(buffType == BuffType.Health)
        {
            playerHealth++;
            PlayerHealthChange?.Invoke(playerHealth);
            Debug.Log("Health Buff Applied" + playerHealth);

        }
        else if(buffType == BuffType.Defense)
        {
            playerMovement.IncreaseDefense();
            Debug.Log("Defense Buff Applied");
        }
    }
  

    public void TakeDamage(int damage)
    {

        if (isDead) 
        { 
            return; 
        }
        
        playerHealth -= damage;

        if (playerHealth < 0)
        {
            playerHealth = 0;
        }

        PlayerHealthChange?.Invoke(playerHealth);


        Debug.Log("Player Health: " + playerHealth);
        if (playerHealth <= 0)
        {
            isDead = true;
            Debug.Log("GAME OVER !!!!");
            PlayerDied?.Invoke();
        }
    }
}
