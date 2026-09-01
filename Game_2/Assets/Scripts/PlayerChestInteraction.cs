using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChestInteraction : MonoBehaviour
{
    private RoundChest currentChest;

    public void OnInteract(InputValue value)
    {
        Debug.Log("E pressed");

        if (!value.isPressed)
        {
            return;
        }

        if (currentChest != null)
        {
            currentChest.GiveRandomBuff();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RoundChest chest = collision.GetComponent<RoundChest>();

        if (chest != null)
        {
            currentChest = chest;
            Debug.Log("Near Chest");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        RoundChest chest = collision.GetComponent<RoundChest>();

        if (chest != null && chest == currentChest)
        {
            currentChest = null;
            Debug.Log("Left Chest");
        }
    }
}