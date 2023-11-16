using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePressao : MonoBehaviour{

    private static int placasAtivadas = 0;
    void Update(){
        Debug.Log("placas ativadas"+placasAtivadas);
    }


    private void OnTriggerEnter(Collider other){
        if(placasAtivadas<2){
            placasAtivadas++;
        }
        
        if (placasAtivadas == 2){
            GlobalVariables.checaPortaAtiva = true;
            Debug.Log("Placa de pressao ativada!");
        }
    }

    private void OnTriggerExit(Collider other){  
        if(placasAtivadas>0){
            placasAtivadas--;
        }
        
        if (placasAtivadas < 2){
            GlobalVariables.checaPortaAtiva = false;
            Debug.Log("Placa de pressao desativada!");
        }
    }
}
