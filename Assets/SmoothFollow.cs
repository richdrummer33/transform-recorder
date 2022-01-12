using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform toFollow;
    public float speed = 2f;

    Vector3 offset = Vector3.up * 0.15f;

    void Update()
    {
        Vector3 targetPos = toFollow.position + offset;

        transform.position += (targetPos - transform.position) * Time.deltaTime * speed;

        Quaternion lookRot = Quaternion.LookRotation(transform.position - Camera.main.transform.position); // Canvas is backwards

        transform.rotation = lookRot;
    }
}
