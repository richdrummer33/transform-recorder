using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetect : MonoBehaviour
{
    public Renderer blockerMat;
    float startDist;
    Color color;

    Vector3 point;
    Vector3 normal;
    float distInside;

    // Start is called before the first frame update
    void Start()
    {
        color = blockerMat.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        point = collision.GetContact(0).point;

        normal = collision.GetContact(0).normal;

        startDist = Vector3.Distance(transform.position, point);
    }

    private void OnCollisionStay(Collision collision)
    {
        distInside = Mathf.Abs(Vector3.Dot(normal, transform.position - point));
        
        float dist = Vector3.Distance(transform.position, point); 

        color.a = Mathf.Clamp(1f - dist / startDist, 0f, 1f);

        blockerMat.material.color = color;
    }

    private void OnCollisionExit(Collision collision) // Just in case
    {
        color.a = 0f;
        
        blockerMat.material.color = color;
    }
}
