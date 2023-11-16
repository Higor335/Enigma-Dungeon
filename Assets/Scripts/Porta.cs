using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour{

    //posições de abertura e fechamento
    private Vector3 posicaoAberta = new Vector3(-66.5f, 4.31f, -1.75f);
    private Vector3 rotacaoAberta = new Vector3(0f, -93.666f, 0f);

    private Vector3 posicaoFechada;
    private Vector3 rotacaoFechada;

    void Awake()
    {
        // Armazena os valores iniciais
        posicaoFechada = transform.position;
        rotacaoFechada = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update(){
        if (GlobalVariables.checaPortaAtiva) {
            AbrirPorta();
            Debug.Log("Porta Abriu!");
        } else {
            FecharPorta();
            Debug.Log(transform.position);
        }
    }

    // Função para abrir a porta
    void AbrirPorta(){
        transform.position = posicaoAberta;
        transform.eulerAngles = rotacaoAberta;
    }

    // Função para fechar a porta
    void FecharPorta(){
        transform.position = posicaoFechada;
        transform.eulerAngles = rotacaoFechada;
    }
}