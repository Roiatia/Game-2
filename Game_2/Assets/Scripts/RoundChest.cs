using UnityEngine;

public class RoundChest : MonoBehaviour
{


    public void GiveRandomBuff()
    {
        int RandomBuff = Random.Range(0, 3);

        if (RandomBuff == 0)
        {
            Debug.Log("Speed Buff");
        }
        else if(RandomBuff == 1)
        {
            Debug.Log("Health Buff");
        }
        else
        {
            Debug.Log("Defense Buff");
        }
    }
    
}
