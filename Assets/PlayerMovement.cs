
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private Rigidbody rgdbdy;
    private void Start()
    {
        rgdbdy = GetComponent<Rigidbody>();
        rgdbdy.freezeRotation = true; // Prevent unwanted rotation
        rgdbdy.constraints = RigidbodyConstraints.FreezePosition;

    }

}


