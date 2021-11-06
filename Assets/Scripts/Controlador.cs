using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public static Controlador gm;
    public float zumbisVivo;
    public Text Zumbis;

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
        zumbisVivo = 2;
    }

   public void matarZombie()
    {
        zumbisVivo -= 1;
        Zumbis.text = "Zumbis: " + zumbisVivo;
    }

    public void addZombie(int qtd)
    {
        zumbisVivo += qtd;
        Zumbis.text = "Zumbis: " + zumbisVivo;
    }


}
