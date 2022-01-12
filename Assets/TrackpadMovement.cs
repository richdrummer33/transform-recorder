using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackpadMovement : MonoBehaviour
{
    public string trackpadAxisX, trackpadAxisY;
    public float speed = 3f;
    public Transform xrRig;
    Rigidbody rb;

    Vector3 direction; // To move in
    public LayerMask mask;

    // Wall Collision
    Vector3 wallCompensation;

    private void Start()
    {
        rb = xrRig.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float trackpadX = Input.GetAxis(trackpadAxisX);
        float trackpadY = Input.GetAxis(trackpadAxisY);

        Vector3 forward = transform.forward * trackpadY;
        forward.y = 0f;

        Vector3 right = transform.right * trackpadX;
        right.y = 0f;

        direction = forward  + right;

        // Lateral Movement
        rb.MovePosition(xrRig.position + (direction + wallCompensation) * Time.fixedDeltaTime * speed);
       
        // Vertical movement - make sure the Xr Rig sticks to the terrain
        Vector3 rigPosition = xrRig.position;
        rigPosition.y = GetFloorHeight();
        xrRig.transform.position = rigPosition; // XR Rig height now = ground hieght
    }

    private float GetFloorHeight()
    {
        float floorHeight;

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Vector3.down, out hit, Mathf.Infinity, mask);

        floorHeight = hit.point.y;

        return floorHeight;
    }

    public void StartWallCollision(Vector3 hitNormal)
    {
        float compensationMagnitude = Vector3.Dot(hitNormal, direction);
        wallCompensation = -hitNormal * compensationMagnitude;
        Debug.Log("comp " + compensationMagnitude);
    }

    public void StopWallCollision()
    {
        wallCompensation = Vector3.zero;
    }
}
