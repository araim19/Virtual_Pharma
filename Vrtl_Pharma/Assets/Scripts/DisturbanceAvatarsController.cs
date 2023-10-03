using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisturbanceAvatarsController : MonoBehaviour
{

    [SerializeField] private  GameObject[] Avatars;

    [SerializeField]  public GameObject[] CharacterList;

    public GameObject TransformSource;
    public GameObject GameObjectMain;

    public bool[] flags;

    private int Disturbance_Level = 3; //1 à 3
    private int NB_Avatars;



    void Start()
    {
        if (PlayerPrefs.HasKey("Disturbance_Level"))
        {
            Disturbance_Level = PlayerPrefs.GetInt("Disturbance_Level");//Defined in the Menu
        }              
        NB_Avatars = Random.Range(Disturbance_Level + 1, 4 * Disturbance_Level - 2);// 2-2 ; 3-6 ; 4-10
        print(NB_Avatars);


        for (int i = 0; i < NB_Avatars; i++)    //Creation du nombre adéquats d'avatars
        {
            CharacterList[i] = Instantiate(GameObjectMain, new Vector3(0, 1, 0), Quaternion.identity, TransformSource.transform);
            Instantiate(Avatars[Random.Range(0, Avatars.Length)], new Vector3(i, 1, 0), Quaternion.identity, CharacterList[i].transform);
            flags[i] = false;
        }
        flags[1] = true;
    }

    // Update is called once per frame
    void Update()
    {
        //On envoie un certain nombre d'avatars en fonction du level
        
        


    }
}
