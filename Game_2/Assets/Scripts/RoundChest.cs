using UnityEngine;
public enum BuffType
{
    Speed,
    Health,
    Defense
}

public class RoundChest : MonoBehaviour
{


    public BuffType GiveRandomBuff()
    {
        int RandomBuff = Random.Range(0, 3);

        if (RandomBuff == 0)
        {
            Debug.Log("Speed Buff");
            return BuffType.Speed;
        }
        else if(RandomBuff == 1)
        {
            Debug.Log("Health Buff");
            return BuffType.Health;
        }
        else
        {
            Debug.Log("Defense Buff");
            return BuffType.Defense;
        }
    }
    

  
}
