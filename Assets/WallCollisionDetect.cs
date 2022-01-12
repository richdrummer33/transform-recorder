using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollisionDetect : MonoBehaviour
{
    public TrackpadMovement trackpadController;

    // Start is called before the first frame update
    void Start()//
    {
        trackpadController = GetComponentInChildren<TrackpadMovement>();
    }
   
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Enter");

        trackpadController.StartWallCollision(collision.GetContact(0).normal);
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
        trackpadController.StopWallCollision();

    }
}
