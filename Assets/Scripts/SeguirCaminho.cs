using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCaminho : MonoBehaviour
{
    [SerializeField] private GameObject[] pontos;
    private int indexPontoAtual = 0;

    [SerializeField] private float speed = 1f;

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(pontos[indexPontoAtual].transform.position, transform.position) < .1f) {
            indexPontoAtual++;
            if (indexPontoAtual >= pontos.Length) {
                indexPontoAtual = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, pontos[indexPontoAtual].transform.position, Time.deltaTime * speed);
    }
}
