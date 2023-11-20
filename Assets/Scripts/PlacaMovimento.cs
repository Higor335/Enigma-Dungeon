using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaMovimento : MonoBehaviour
{
    private Vector3 posicaoOriginal;

    [SerializeField] GameObject placa;
    public AudioClip somMovimentoClip; // Variável pública para o AudioClip
    private AudioSource somMovimento;

    bool voltar = false;
    bool jogadorNaPlaca = false;  // Adicionada para rastrear se o jogador está na placa.
    bool somTocado = false;  // Adicionada para rastrear se o som já foi tocado nesta interação.

    public void Start()
    {
        posicaoOriginal = transform.position;

        // Verifica se o AudioSource já está presente ou não.
        somMovimento = placa.GetComponent<AudioSource>();
        if (somMovimento == null)
        {
            // Adiciona o componente AudioSource se não estiver presente.
            somMovimento = placa.AddComponent<AudioSource>();
        }

        // Configurações do AudioSource
        somMovimento.playOnAwake = false;
        somMovimento.loop = false;
        somMovimento.clip = somMovimentoClip;
    }

    private void OnTriggerStay(Collider other)
    {
        // Se o jogador está na placa e a placa está abaixando
        if (jogadorNaPlaca && placa.transform.position.y > posicaoOriginal.y - 0.05f)
        {
            placa.transform.Translate(new Vector3(0, -0.1f, 0) * Time.deltaTime);

            // Inicie a reprodução do som apenas se não estiver tocando e ainda não foi tocado nesta interação.
            if (!somMovimento.isPlaying && !somTocado)
            {
                somMovimento.Play();
                somTocado = true;
            }
        }

        voltar = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!somMovimento.isPlaying)  // Inicie o som apenas se não estiver tocando.
        {
            somMovimento.Play();
            somTocado = true;
        }

        other.transform.parent = transform;
        jogadorNaPlaca = true;
    }

    private void OnTriggerExit(Collider other)
    {
        voltar = true;
        other.transform.parent = null;
        jogadorNaPlaca = false;

        // Reinicie a flag para que o som possa ser tocado novamente na próxima interação.
        somTocado = false;

        // Pare o som quando a placa para de se movimentar.
        somMovimento.Stop();
    }

    private void Update()
    {
        if (voltar)
        {
            if (placa.transform.position.y < posicaoOriginal.y)
            {
                placa.transform.Translate(new Vector3(0, 0.1f, 0) * Time.deltaTime);

                // Reinicie a flag para que o som possa ser tocado novamente.
                somTocado = false;
            }
            else
            {
                voltar = false;
            }
        }
    }
}
