using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private int playerHealth = 10;

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
            Debug.Log("Health Buff Applied" + playerHealth);

        }
        else if(buffType == BuffType.Defense)
        {
            playerMovement.IncreaseDefense();
            Debug.Log("Defense Buff Applied");
        }
    }
  
}
