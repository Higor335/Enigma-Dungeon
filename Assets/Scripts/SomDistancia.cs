using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomDistancia : MonoBehaviour{

    public float distanciaMaxima = 10f;
    public float volumeMaximo = 0.15f;
    public float tempoDeTransicaoAumento = 1f;

    private AudioSource audioSource;
    private Transform jogador;
    private bool emTransicao = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        jogador = Camera.main.transform;
    }

    void Update()
    {
        float distanciaAoJogador = Vector3.Distance(transform.position, jogador.position);

        if (distanciaAoJogador <= distanciaMaxima)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            StartCoroutine(TransicaoVolume(distanciaAoJogador, tempoDeTransicaoAumento));
        }
        else
        {
            if (audioSource.isPlaying && !emTransicao)
            {
                audioSource.Stop();
            }
        }
    }

    IEnumerator TransicaoVolume(float distanciaAoJogador, float tempoDeTransicao)
    {
        if (emTransicao)
            yield break;

        emTransicao = true;

        float volumeInicial = audioSource.volume;
        float volumeFinal = Mathf.Clamp01((distanciaMaxima - distanciaAoJogador) / distanciaMaxima) * volumeMaximo;

        float tempoDecorrido = 0f;

        while (tempoDecorrido < tempoDeTransicao)
        {
            audioSource.volume = Mathf.Lerp(volumeInicial, volumeFinal, tempoDecorrido / tempoDeTransicao);
            tempoDecorrido += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = volumeFinal;

        emTransicao = false;
    }
}
