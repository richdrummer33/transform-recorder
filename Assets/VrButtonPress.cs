using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrButtonPress : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hand")
        {
            GetComponent<Button>().onClick.Invoke(); // Run all functions defined in "OnClick" for the button component attached to this game object
        }
    }
}
