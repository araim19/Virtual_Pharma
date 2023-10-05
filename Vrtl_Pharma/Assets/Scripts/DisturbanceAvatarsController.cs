using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class DisturbanceAvatarsController : MonoBehaviour
{

    [SerializeField] private GameObject[] Avatars; //Liste des avatars à notre disposition

    [SerializeField] public GameObject[] CharacterList; //Liste des avatars qui viendront dans le magasin

    [SerializeField] public GameObject dialogue;

    private int i = 0;
    private bool caninstante = true;

    public GameObject TransformSource;
    public GameObject GameObjectMain;


    private int Disturbance_Level = 3; //1 à 3
    public static int NB_Avatars;



    public Vector3[] destinations;
    private int cpt = 0;
    private int incrementonly = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("Disturbance_Level"))
        {
            Disturbance_Level = PlayerPrefs.GetInt("Disturbance_Level");//Defined in the Menu
        }              
        NB_Avatars = UnityEngine.Random.Range(Disturbance_Level + 1, 4 * Disturbance_Level - 2);// 2-2 ; 3-6 ; 4-10
        print(NB_Avatars);

    }

    // Update is called once per frame
    void Update()
    {

        //-------------------------------------------------Instantiate-----------------------------------------
        if (caninstante)        
        {
            caninstante = false;
            CharacterList[i] = Instantiate(GameObjectMain, new Vector3(0, 0, 0), Quaternion.identity, TransformSource.transform);
            Instantiate(Avatars[UnityEngine.Random.Range(0, Avatars.Length)], new Vector3(0, 1, 0), Quaternion.identity, CharacterList[i].transform);
            Instantiate(dialogue, new Vector3(-1f, 2, 0.5f), new Quaternion(0f,180f,0f,0f), CharacterList[i].transform);
            StartCoroutine(Coroutinewait());
            cpt++;
            incrementonly++;
            UpdateAllDest();
            i++;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            print("destruction");
            UpdateAgentDest(0, 10);
            cpt--;
            RemoveElement(ref CharacterList, 0);
            UpdateAllDest();
        }

        //test sur la destination {Instantiate(dialogue, new Vector3(-1f, 2, 0.5f), new Quaternion(0f,180f,0f,0f), CharacterList[0].transform);}

    }


    IEnumerator Coroutinewait()
    {
        yield return new WaitForSeconds(0.5f);
        if (incrementonly != NB_Avatars)
        {
            caninstante = true;
        }
         
    }



    //---------------------------------------Navmesh---------------------------------------------

    public void UpdateAllDest()
    {
        int indextemp = 0;
        for(int i = 0; i < cpt; i++)
        {
            UpdateAgentDest(indextemp, indextemp);  //First in charlist has to come first in destinations
            indextemp++;
        }        
    }

    public void UpdateAgentDest(int agentindex, int destinationindex)
    {
        CharacterList[agentindex].GetComponent<NavMeshAgent>().SetDestination(destinations[destinationindex]); //GetComponentInChildren<NavMeshAgent>().
    }

    public void RemoveElement<T>(ref T[] arr, int index)
    {
        for(int i=index;i<cpt; i++)
        {
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, arr.Length - 1);
    }

}
