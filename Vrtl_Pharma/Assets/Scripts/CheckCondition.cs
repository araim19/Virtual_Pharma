using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckCondition : MonoBehaviour
{
    //Récupérer bon scénario
    //Récupérer dernier mot scénario et stocker dans var
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
    //Vérifier que si objet qui contient mot scénario entre dans zone collider, appeler fonction Completed()



}
