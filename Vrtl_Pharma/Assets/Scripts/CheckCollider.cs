using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollider : MonoBehaviour
{
    public static string objectname = "";
    public GameObject lastone = null;

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        objectname = other.name;
        if (PlayerPrefs.GetInt("Niveau") > 0 && PlayerPrefs.GetInt("Niveau") < 4)
        {
            if (objectname.Contains(LoadDialoge._nomMedoc))
            {
                Destroy(other.gameObject);
            }
        }
    }

}
