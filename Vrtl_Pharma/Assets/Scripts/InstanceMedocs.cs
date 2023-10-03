using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceMedocs : MonoBehaviour
{
    public GameObject [] medocsPrefabs;
    public Transform coordonnees;
    void Start()
    {
        for(int i=0; i<medocsPrefabs.Length; i++){
            Instantiate(medocsPrefabs[i], new Vector3(coordonnees.position.x, coordonnees.position.y + i*3 + 1, coordonnees.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
