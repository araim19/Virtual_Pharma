using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class DisturbanceAvatarsController : MonoBehaviour
{

    [SerializeField] private GameObject[] AvatarsF; //Liste des avatars f�minins � notre disposition
    [SerializeField] private GameObject[] AvatarsM; //Liste des avatars masculins � notre disposition

    [SerializeField] public GameObject[] CharacterList; //Liste des avatars qui viendront dans le magasin

    [SerializeField] public GameObject dialogue;

    private int i = 0;
    private bool caninstante = true;

    public GameObject TransformSource;
    public GameObject GameObjectMain;

    private GameObject Temp;

    private bool autorize = false; //Avoid error with null array
    private bool lookatauto = true;


    private int Disturbance_Level = 2; //1 � 3 //PlayerPrefs.GetInt(Niveau);
    public static int NB_Avatars;

    public Transform Player;

    public Transform[] destinations;
    private Vector3 target;

    private int cpt = 0;
    private int incrementonly = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("Niveau"))
        {
            Disturbance_Level = PlayerPrefs.GetInt("Niveau");//Defined in the Menu
            if(Disturbance_Level != 0)
            {
                NB_Avatars = UnityEngine.Random.Range(Disturbance_Level + 1, 4 * Disturbance_Level - 2);// 2-2 ; 3-6 ; 4-10
                print(NB_Avatars);
            }
            else
            {
                NB_Avatars = 0;
                caninstante = false;
            }

        }
        else
        {
            NB_Avatars = 1;
            print(NB_Avatars);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        //-------------------------------------------------Instantiate-----------------------------------------
        if (caninstante)        
        {
            caninstante = false;
            CharacterList[i] = Instantiate(GameObjectMain, new Vector3(0, 0, 8), Quaternion.identity, TransformSource.transform);
            CharacterList[i].name += i;
            int random = UnityEngine.Random.Range(0, 2);//determine avatar F ou M
            if(random == 0)
            {
                var michel = Instantiate(AvatarsF[UnityEngine.Random.Range(0, AvatarsF.Length)], new Vector3(0, -0.1f, 8), Quaternion.identity, CharacterList[i].transform);
                michel.tag = "F";
            }
            else if(random == 1)
            {
                var michel = Instantiate(AvatarsM[UnityEngine.Random.Range(0, AvatarsM.Length)], new Vector3(0, -0.1f, 8), Quaternion.identity, CharacterList[i].transform);
                michel.tag = "M";
            }
            
            CharacterList[i].tag = "Not_Talking";
            //Instantiate(dialogue, new Vector3(-1f, 2, 0.5f), new Quaternion(0f,180f,0f,0f), CharacterList[i].transform);
            StartCoroutine(Coroutinewait());
            cpt++;
            incrementonly++;
            UpdateAllDest();
            i++;
        }

        if (Input.GetKeyDown(KeyCode.D)) //for debug
        {
            Completed();
        }


        if (autorize)
        {
            //StartCoroutine(CoroutineLookAt());
            if (Vector3.Distance(CharacterList[0].transform.position, destinations[0].position) < 0.2 && CharacterList[0].tag != "Talking")
            {
                string temptag = "";
                foreach (Transform child in CharacterList[0].transform)
                {
                    if (child.tag == "F")
                    {
                        temptag = "F";
                    }
                    else { temptag = "M"; }
                }
                print(CharacterList[0].name);
                CharacterList[0].tag = "Talking";
                Temp = Instantiate(dialogue, new Vector3(-1f, 2, 0.2f), new Quaternion(0f, 0f, 0f, 0f), CharacterList[0].transform);
                Temp.tag = temptag;
                Temp.transform.localPosition = new Vector3(-1f, 2, 0.5f);
                Temp.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
            }

            if (CharacterList.Length > 1)
            {
                
                for (int ii = 1; ii < cpt; ii++)
                {
                    if (Vector3.Distance(CharacterList[ii].transform.position, destinations[ii].position) > 0.2 && CharacterList[ii].tag != "Walking")
                    {
                        CharacterList[ii].tag = "Walking";
                    }
                    else if (Vector3.Distance(CharacterList[ii].transform.position, destinations[ii].position) < 0.2 && CharacterList[ii].tag != "Idle")
                    {
                        CharacterList[ii].tag = "Idle";
                    }
                    /*if (Vector3.Distance(CharacterList[0].transform.position, destinations[0].position) < 0.4)
                    {
                        print("debug");
                        CharacterList[0].tag = "Talking";
                    }*/
                }
            }
        }



        if (CheckCondition.gonext)
        {
            print("bon produit");
            Completed();
            CheckCondition.gonext = false;
        }
    }


    IEnumerator Coroutinewait()
    {
        autorize = true;
        yield return new WaitForSeconds(3f);        //temps d'attente entre 2 avatars !!!
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
        CharacterList[0].tag = "Walking";
        Destroy(Temp);
        UpdateAgentDest(0, 10);
        cpt--;
        RemoveElement(ref CharacterList, 0);
        UpdateAllDest();
    }

}
