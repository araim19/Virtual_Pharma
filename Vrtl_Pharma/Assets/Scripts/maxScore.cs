using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class maxScore : MonoBehaviour
{
    private TextMeshProUGUI _maxScoreText;
    private int _maxScore;
    private GameObject[] cartonsInfl;
    private GameObject[] cartonsDoul;
    void Start()
    {
        cartonsInfl = GameObject.FindGameObjectsWithTag("CartonInfl");
        cartonsDoul = GameObject.FindGameObjectsWithTag("CartonDoul");
        Debug.Log("doul:"+cartonsDoul.Length);
        Debug.Log("infl:"+cartonsInfl.Length);
        _maxScoreText = GameObject.Find("maxScoreUI").GetComponent<TextMeshProUGUI>();

        _maxScore = (cartonsDoul.Length * 15) + (cartonsInfl.Length * 8);
        _maxScoreText.text = "/" + _maxScore.ToString();
    }
}
