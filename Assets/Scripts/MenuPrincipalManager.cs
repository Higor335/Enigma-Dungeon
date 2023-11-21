using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelDificuldade;

    public static string dificuldade = "normal"; // Cria variavel estática (variavel global)

    public Button btNormal, btHardcore;

    void Start()
    {
        // Listener dos botões
        btNormal.onClick.AddListener(() => SelecionarDificuldade(btNormal));
        btHardcore.onClick.AddListener(() => SelecionarDificuldade(btHardcore));
    }

    public void Jogar()
    {
        //Screen.SetResolution(1308, 669, true);
        //Inimigo.pontuacao = 0; // Reseta Pontuação
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void SelecionarDificuldade(Button button) // Verifica a dificuldade de acordo com o botão escolhido
    {
        switch (button.name)
        {
            /*
            case "btFacil":
                dificuldade = "facil"; // Atualiza a String dificuldade para "facil"
                Debug.Log(dificuldade);
                Jogar();  // chama a função jogar()
                break;
            */
            case "btNormal":
                dificuldade = "normal"; // Atualiza a String dificuldade para "medio"
                Debug.Log(dificuldade);
                Jogar();  // chama a função jogar()
                break;
            case "btHarcore":
                dificuldade = "hardcore"; // Atualiza a String dificuldade para "dificil"
                Debug.Log(dificuldade);
                Jogar(); // chama a função jogar()
                break;
        }
    }

    public void AbrirDificuldade()
    {
        painelMenuInicial.SetActive(false);
        painelDificuldade.SetActive(true);
    }

    public void FecharDificuldade()
    {
        painelMenuInicial.SetActive(true);  
        painelDificuldade.SetActive(false);
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void Fecharopcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
