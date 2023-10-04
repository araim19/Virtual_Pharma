using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject [] myPrefab;
    private TextMeshProUGUI scoreText;
    private uint score;

    private void Start(){
        scoreText = GameObject.Find("scoreUI").GetComponent<TextMeshProUGUI>();
        score = uint.Parse(scoreText.text);
        scoreText.text = score.ToString();
        
    }

    private void OnTriggerEnter(Collider other){
        try{     
            score = uint.Parse(scoreText.text); //Met à jour le score dans le script
            for(int i=0; i<myPrefab.Length; i++){
                if(other.name.Substring(other.name.IndexOf("_")/*, other.name.IndexOf("(")-other.name.IndexOf("_")*/) == "_bis"){   //si c'est un "bis"
                    if(other.name.Substring(0, other.name.IndexOf("_")) == myPrefab[i].name){ //SI un des prefabs porte le nom de celui qui vient d'être amené sans le _bis
                        Debug.Log("objet bis:" + other.name);
                        Debug.Log("colision avec:"+gameObject.name);
                        score++;
                        scoreText.text = score.ToString();
                        Destroy(other.gameObject);
                        Instantiate(myPrefab[i], new Vector3(gameObject.transform.position.x-0.6f+((score%5)*0.3f),0.75f+(i%10*0.5f),gameObject.transform.position.z), Quaternion.identity);
                    }
                } 
            }
        }
        catch{
            //Debug.Log("------------------");
            //Debug.Log("colision avec:"+gameObject.name);
        }
    }
}
