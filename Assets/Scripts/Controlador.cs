using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public static Controlador gm;
    public float zumbisVivo;
    public Text Zumbis;
    public int faseAtual = 0;
    public GameObject TelaFinal;
    public GameObject TelaPause;
    public GameObject TelaGameOver;

    void Awake()
    {
        if (gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        zumbisVivo = 0;
    }

   public void matarZombie(GameObject zumbi)
    {

        zumbisVivo -= 1;
        Zumbis.text = "Zumbis: " + zumbisVivo;
        if (zumbisVivo < 0)
        {
            zumbisVivo = 0;
        }
    }


    public void instanciarZumbie(GameObject inimigo, Transform posicao)
    {
        Instantiate(inimigo, posicao.transform.position, posicao.transform.rotation);
        addZombie(1);
    }

    public void addZombie(int qtd)
    {
        
        zumbisVivo += qtd;
        Zumbis.text = "Zumbis: " + zumbisVivo;
    }

    public void EndGame()
    {
        TelaFinal.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void Morte()
    {
        TelaGameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
      
    }


}
