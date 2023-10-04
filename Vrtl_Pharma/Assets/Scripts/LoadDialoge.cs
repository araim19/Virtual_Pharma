using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
public class LoadDialoge : MonoBehaviour
{
    public AudioSource _dialAudio;
    public String scenarioScriptPATH;
    public GameObject canvasDialog;
    private int _numLigne;
    private TextMeshProUGUI _dialogue;
    private String[] _lines;
    private bool _delayPassed = true;
    void Start()
    {
        _dialAudio.Play();
        _numLigne = 0;
        _lines = File.ReadAllLines(scenarioScriptPATH);
        canvasDialog.SetActive(true);
        _dialogue = GameObject.Find("DialogUI").GetComponent<TextMeshProUGUI>();
        _dialogue.text = "coucou";   
    }

    // Update is called once per frame
    void Update()
    {
        if(_delayPassed){
            Debug.Log("lines:"+_lines.Length);
            Debug.Log("numLigne:"+_numLigne);
            _dialogue.text = _lines[_numLigne];
            _delayPassed = false;
            StartCoroutine(enumerator());
        }
    }

    IEnumerator enumerator(){
        yield return new WaitForSeconds(3);
        if(_numLigne < _lines.Length-1){
            _numLigne++;
            _delayPassed = true;
        }
        else{

            CloseDialog();
        }
    }

    void CloseDialog(){
        canvasDialog.SetActive(false);
    }
}
