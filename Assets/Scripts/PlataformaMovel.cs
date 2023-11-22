using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        other.gameObject.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision other) {
        other.gameObject.transform.SetParent(null);
    }
}
