using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePressao : MonoBehaviour{

    private static int placasAtivadas = 0;

    void Start(){
        placasAtivadas = 0;
        GlobalVariables.checaPortaAtiva = false;
    }

    private void OnTriggerEnter(Collider other){
        placasAtivadas++;
        if (placasAtivadas == 2){
            GlobalVariables.checaPortaAtiva = true;
            Debug.Log("Placa de pressao ativada!");
        }
    }

    private void OnTriggerExit(Collider other){  
        placasAtivadas--;
        if (placasAtivadas < 2){
            GlobalVariables.checaPortaAtiva = false;
            Debug.Log("Placa de pressao desativada!");
        }
    }
}