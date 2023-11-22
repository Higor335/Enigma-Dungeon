using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuFim : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Screen.lockCursor = false;
    }
   public void VoltarParaMenu()
    {
        SceneManager.LoadScene(0);
            
    }

    public void SairDoJogo()
    {
        Debug.Log("Saindo");
        Application.Quit();
    }
}