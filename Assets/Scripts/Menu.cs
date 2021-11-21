using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OpenMenu()
    {//Chama no Onclick do botao de menu
        SceneManager.LoadScene("TelaInicial");

    }

    public void OpenGame()
    {//Chama no Onclick do botao de jogar

        SceneManager.LoadScene("Introducao");
    }

    public void HowtoPlay()
    {//Chama no Onclick do botao de menu
        SceneManager.LoadScene("Como Jogar");

    }
    public void Quit()
    {
        Application.Quit();

    }
}
