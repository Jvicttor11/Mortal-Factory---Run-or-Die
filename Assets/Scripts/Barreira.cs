using System;   
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Barreira : MonoBehaviour
{

    public int addInimigo=2;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidindo: "+ Controlador.gm.zumbisVivo);
        if (Controlador.gm.zumbisVivo == 0)
        {
            Controlador.gm.addZombie(addInimigo);
            Destroy(gameObject);
        }
    }
}
