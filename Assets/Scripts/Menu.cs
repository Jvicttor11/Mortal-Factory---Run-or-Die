using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OpenMenu()
    {//Chama no Onclick do botao de menu
        SceneManager.LoadScene("Menu");

    }

    public void OpenGame()
    {//Chama no Onclick do botao de jogar

        SceneManager.LoadScene("Fase1");
    }
}
