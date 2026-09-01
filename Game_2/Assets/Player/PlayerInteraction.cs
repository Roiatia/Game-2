using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{

    private PackageCollect currentPackage;
    private bool isCarryingPackage;



    //public void OnInteract(InputValue value)
    //{
    //    Debug.Log("Interact pressed");

    //    if (!value.isPressed)
    //    {
    //        return;
    //    }

    //    if (currentPackage != null && !isCarryingPackage)
    //    {
    //        currentPackage.Collect();
    //        currentPackage = null;
    //        isCarryingPackage = true;

    //        Debug.Log("Package Collected");
    //    }
    //}


    public void OnInteract()
    {
        Debug.Log("Interact pressed");

        if (currentPackage != null && !isCarryingPackage)
        {
            currentPackage.Collect();
            currentPackage = null;
            isCarryingPackage = true;

            Debug.Log("Package Collected");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered trigger: " + collision.name);

        PackageCollect package = collision.GetComponent<PackageCollect>();

        if (package != null)
        {
            currentPackage = package;
            Debug.Log("Near package");
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
