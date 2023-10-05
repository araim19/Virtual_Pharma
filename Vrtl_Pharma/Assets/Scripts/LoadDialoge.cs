using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
public class LoadDialoge : MonoBehaviour
{
    private AudioSource _source;
    public AudioClip[] audioClips;
    public String[] scenarioScriptsPATH;
    public GameObject canvasDialog;
    private int _numLigne;
    private TextMeshProUGUI _dialogue;
    private String[] _lines;
    private bool _delayPassed = true;
    void Start()
    {
        int idScenario = UnityEngine.Random.Range(0, audioClips.Length);
        _source = GetComponent<AudioSource>();
        _source.clip = audioClips[idScenario];
        _source.Play();

        _numLigne = 0;
        _lines = File.ReadAllLines(scenarioScriptsPATH[idScenario]);
        canvasDialog.SetActive(true);
        _dialogue = GameObject.Find("DialogUI").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(_delayPassed){
            if(_numLigne == _lines.Length-1)
                _dialogue.color = Color.green;
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
    }
}
