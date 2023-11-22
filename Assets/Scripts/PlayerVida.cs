using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVida : MonoBehaviour
{
    private string dif = "normal";

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        if (MenuPrincipalManager.dificuldade != null && MenuPrincipalManager.dificuldade != "")
        {
            dif = MenuPrincipalManager.dificuldade;
        }

        if (dif == "hardcore")
        {
            RestartHard();
        } else {
            Restart();
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void RestartHard()
    {
        SceneManager.LoadScene(0);
    }
}
