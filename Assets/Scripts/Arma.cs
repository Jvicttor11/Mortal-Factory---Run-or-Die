using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public AudioSource AudioTiro;
    public AudioSource[] AudioRecarregar;

    public void atirar()
    {
        AudioTiro.Play();
    }

    public void recarregar()
    {
        for (var i = 0; i < AudioRecarregar.Length; i++)
        {

            StartCoroutine(Aguardar(AudioRecarregar[i].time));
   
        }

    }

    IEnumerator Aguardar(float tempoAEsperar)
    {
        yield return new WaitForSeconds(tempoAEsperar);

    }
}
