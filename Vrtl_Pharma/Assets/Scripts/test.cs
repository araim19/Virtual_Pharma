using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private uint score;

    private void Start(){
        score = 0;
        scoreText.text = "coucou";
    }

    private void OnTriggerEnter(Collider other){
        score++;
        scoreText.text = score.ToString();
        gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other){
        gameObject.SetActive(true);
    }
}
