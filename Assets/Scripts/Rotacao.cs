using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    [SerializeField] private float velocidade = 1.5f;
    private void Update()
    {
        transform.Rotate(0, 0, 360 * velocidade * Time.deltaTime);
    }
}
