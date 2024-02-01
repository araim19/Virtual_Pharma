using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{

    private bool peut_decrocher = false;
    private bool peut_decrocher2 = false;
    public AudioClip Dring;
    public AudioClip Audio1;
    public AudioClip Audio2;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("Niveau"))
        {
            if (PlayerPrefs.GetInt("Niveau") == 0)
            {
                StartCoroutine(CoroutinePhone());
            }
        }

    }

    IEnumerator CoroutinePhone()
    {
        print("start to wait");
        yield return new WaitForSeconds(10f);        //temps d'attente pour le premier coup de tel
        source.clip = Dring;
        source.Play();
        peut_decrocher = true;
        print(peut_decrocher);

    }

    IEnumerator CoroutinePhone2()
    {
        yield return new WaitForSeconds(90f);        //temps d'attente entre les 2 coup de tel modifiable
        source.clip = Dring;
        source.Play();
        peut_decrocher2 = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other.name);
        if (peut_decrocher)
        {
            source.Stop();
            source.clip = Audio1;
            source.Play();
            peut_decrocher = false;
            StartCoroutine(CoroutinePhone2());
        }

        if (peut_decrocher2)
        {
            source.Stop();
            source.clip = Audio2;
            source.Play();
            peut_decrocher2 = false;
        }

    }


}
