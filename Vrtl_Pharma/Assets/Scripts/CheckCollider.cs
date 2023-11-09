using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public static string objectname = "";

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        objectname = other.name;
    }

}
