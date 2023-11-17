using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaMovimento : MonoBehaviour
{
    private Vector3 posicaoOriginal;

    [SerializeField] GameObject placa;
    bool voltar = false;

    public void Start() {
        posicaoOriginal = transform.position;
    }

    private void OnTriggerStay(Collider other) {
        if (placa.transform.position.y >  posicaoOriginal.y-0.05f) {
            placa.transform.Translate(new Vector3(0,-0.1f,0) * Time.deltaTime);
        }
        voltar = false;
    }

    private void OnTriggerEnter(Collider other) {
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other) {
        voltar = true;
        other.transform.parent = null;
    }

    private void Update() {
        if(voltar){
            if(placa.transform.position.y < posicaoOriginal.y){
                placa.transform.Translate(new Vector3(0,0.1f,0) * Time.deltaTime);
            }
            else{
                voltar = false;
            }
        }
    }
}
