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
    public AudioClip[] audioClipsF;
    public AudioClip[] audioClipsM;
    public String[] scenarioScriptsFPATH;

    public String[] scenarioScriptsMPath;
    public GameObject canvasDialog;
    private int _numLigne;
    private TextMeshProUGUI _dialogue;
    private String[] _lines;
    private bool _delayPassed = true;
    public static String _nomMedoc;
    void Start()
    {
        print(gameObject.name);
        print(gameObject.tag);
        if (gameObject.tag.ToString() == "F"){
            int idScenario = UnityEngine.Random.Range(0, audioClipsF.Length);
            _source = GetComponent<AudioSource>();
            _source.clip = audioClipsF[idScenario];
            _source.Play();
            _numLigne = 0;
            _lines = File.ReadAllLines(scenarioScriptsFPATH[idScenario]);
            canvasDialog.SetActive(true);
            _dialogue = GameObject.Find("DialogUI").GetComponent<TextMeshProUGUI>();

            _nomMedoc = _lines[_lines.Length-1];
            _nomMedoc = _nomMedoc.Substring(12);
        }
        else{
            int idScenario = UnityEngine.Random.Range(0, audioClipsM.Length);
            _source = GetComponent<AudioSource>();
            _source.clip = audioClipsM[idScenario];
            _source.Play();
            _numLigne = 0;
            _lines = File.ReadAllLines(scenarioScriptsMPath[idScenario]);
            canvasDialog.SetActive(true);
            _dialogue = GameObject.Find("DialogUI").GetComponent<TextMeshProUGUI>();

            _nomMedoc = _lines[_lines.Length-1];
            _nomMedoc = _nomMedoc.Substring(12);
        }
    }

    void Update()
    {
        if(_delayPassed){
            if(_numLigne == _lines.Length-1){
                _dialogue.color = Color.green;
                //_nomMedoc = _lines[_numLigne];
            }
            //Debug.Log("lines:"+_lines.Length);
           //Debug.Log("numLigne:"+_numLigne);
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
