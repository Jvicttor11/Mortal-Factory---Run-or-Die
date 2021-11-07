using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnInimigo : MonoBehaviour
{

    public GameObject inimigo;
    public Transform[] SpawnsFases;
    private Transform[] objects;
    public int[] QtdInimigosFase;
    
    private int faseAtual;
    // Start is called before the first frame update
    void Start()
    {
        faseAtual = Controlador.gm.faseAtual;
        CarregarSpawns();
        Aguardar(2);
        //Debug.Log(" Quantidade de Inimidos: " + QtdInimigosFase[Controlador.gm.faseAtual]);
        for (var i = 0; i < QtdInimigosFase[Controlador.gm.faseAtual]; i++)
        {
            int posicao = Random.Range(0, objects.Length);
            Controlador.gm.instanciarZumbie(inimigo, objects[posicao]);
        }
    }

    public void CarregarSpawns()
    {
        objects = SpawnsFases[Controlador.gm.faseAtual].GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (faseAtual != Controlador.gm.faseAtual)
        {
            Start();
        }
    }

    IEnumerator Aguardar(float tempoAEsperar)
    {
        yield return new WaitForSeconds(tempoAEsperar);

    }
}
