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

    private GameObject Temp;

    private bool autorize = false; //Avoid error with null array
    private bool lookatauto = true;


    private int Disturbance_Level = 3; //1 à 3
    public static int NB_Avatars;

    public Transform Player;

    public Transform[] destinations;
    private Vector3 target;

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
            //Instantiate(dialogue, new Vector3(-1f, 2, 0.5f), new Quaternion(0f,180f,0f,0f), CharacterList[i].transform);
            StartCoroutine(Coroutinewait());
            cpt++;
            incrementonly++;
            UpdateAllDest();
            i++;
        }

        if (Input.GetKeyDown(KeyCode.D)) //for debug
        {
            Destroy(Temp);
            print("destruction");
            UpdateAgentDest(0, 10);
            cpt--;
            RemoveElement(ref CharacterList, 0);
            UpdateAllDest();
        }

        if (autorize)
        {
            //StartCoroutine(CoroutineLookAt());
            if (Vector3.Distance(CharacterList[0].transform.position, destinations[0].position) < 1 && CharacterList[0].GetComponentsInChildren<Transform>().Length<3)
            {
                Temp = Instantiate(dialogue, new Vector3(-1f, 2, 0.5f), new Quaternion(0f, 0f, 0f, 0f), CharacterList[0].transform);
                Temp.transform.localPosition = new Vector3(-1f, 2, 0.5f);
            }
        }
    }


    IEnumerator Coroutinewait()
    {
        autorize = true;
        yield return new WaitForSeconds(3f);
        if (incrementonly != NB_Avatars)
        {
            caninstante = true;
        }
         
    }

    IEnumerator CoroutineLookAt()
    {
        lookatauto = false;
        yield return new WaitForSeconds(4);
        CharacterList[0].transform.LookAt(Player.forward);
        lookatauto = true;
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
        target = destinations[destinationindex].position;
        CharacterList[agentindex].GetComponent<NavMeshAgent>().SetDestination(target); //GetComponentInChildren<NavMeshAgent>().
    }

    public void RemoveElement<T>(ref T[] arr, int index)
    {
        for(int i=index;i<cpt; i++)
        {
            arr[i] = arr[i + 1];
        }
        Array.Resize(ref arr, arr.Length - 1);
    }


    public void Completed()
    {
        Destroy(Temp);
        UpdateAgentDest(0, 10);
        cpt--;
        RemoveElement(ref CharacterList, 0);
        UpdateAllDest();
    }

}
