using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class testMedoc : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.name == LoadDialoge._nomMedoc){
            Debug.Log("Bon medoc!");
            Destroy(other.gameObject);
        }
    }
}
