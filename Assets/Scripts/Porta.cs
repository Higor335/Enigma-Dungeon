using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    private Vector3 posicaoAberta = new Vector3(-66.5f, 4.31f, -1.75f);
    private Vector3 rotacaoAberta = new Vector3(0f, -93.666f, 0f);

    private Vector3 posicaoFechada;
    private Vector3 rotacaoFechada;

    private AudioSource SomAbrindo;
    private AudioSource SomFechando;

    public AudioClip PortaAbrindo;
    public AudioClip PortaFechando;

    private bool portaAberta = false;

    void Start()
    {

        SomAbrindo = gameObject.AddComponent<AudioSource>();
        SomAbrindo.clip = PortaAbrindo;

        SomFechando = gameObject.AddComponent<AudioSource>();
        SomFechando.clip = PortaFechando;

        // Armazena os valores iniciais
        posicaoFechada = transform.position;
        rotacaoFechada = transform.eulerAngles;
        
    }

    void Update()
    {
        if (GlobalVariables.checaPortaAtiva && !portaAberta)
        {
            AbrirPorta();
            Debug.Log("Porta Abriu!");
        }
        else if (!GlobalVariables.checaPortaAtiva && portaAberta)
        {
            FecharPorta();
            Debug.Log(transform.position);
        }
    }

    void AbrirPorta()
    {
        SomAbrindo.Play();
        transform.position = posicaoAberta;
        transform.eulerAngles = rotacaoAberta;
        portaAberta = true;
    }

    void FecharPorta()
    {
        SomFechando.Play();
        transform.position = posicaoFechada;
        transform.eulerAngles = rotacaoFechada;
        portaAberta = false;
    }
}
