using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckCondition : MonoBehaviour
{
    //R�cup�rer bon sc�nario
    //R�cup�rer dernier mot sc�nario et stocker dans var
    private string nommedoc;
    public static bool gonext = false;
    private DisturbanceAvatarsController DAC;
    public void Start()
    {
        nommedoc = LoadDialoge._nomMedoc;
    }

    public void Update()
    {
        if (CheckCollider.objectname.Contains(nommedoc))
        {
            gonext = true;
            CheckCollider.objectname = "";
        }
    }
    //V�rifier que si objet qui contient mot sc�nario entre dans zone collider, appeler fonction Completed()



}
