using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ScriptMosquito : MonoBehaviour
{

    public float speed = 3;
    public GameObject mosquito;
    public GameObject mosquitoPrefab;
    public AudioSource somMosquito;
    private bool isPlaying = false;
    private bool moveDireita = false;
    private void deletaMosquito()
    {
        this.mosquito.SetActive(false);
        this.moveDireita = true;
        ScriptBtn_Valvula.comeco = false;
    }
    private void paraMosquito()
    {
        this.moveDireita = false;
    }

    private void pausaAudio()
    {
        this.somMosquito.Pause();
        isPlaying = false;

    }
    private void playAudioSource()
    {
        if(isPlaying == false)
        {
            this.somMosquito.Play();
            isPlaying = true;
            Invoke("pausaAudio", 4);
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptBtn_Valvula.hasPressed && !this.moveDireita && ScriptBtn_Valvula.comeco)
        {
            this.playAudioSource();
            this.mosquitoPrefab.transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            Invoke("deletaMosquito", 5);
        }
        if (ScriptBtn_Valvula.comeco)
        {
            this.mosquito.SetActive (true);
        }
        if (this.moveDireita)
        {
            this.mosquitoPrefab.transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            Invoke("paraMosquito", 5);
        }
    }

}
