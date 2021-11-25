using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnInimigo : MonoBehaviour
{

    public GameObject[] inimigos;
    public Transform[] SpawnsFases;
    private Transform[] objects;
    public int[] QtdInimigosFase;
    
    private int faseAtual;
    // Start is called before the first frame update
    void Start()
    {

        faseAtual = Controlador.gm.faseAtual;

        StartCoroutine(CarregarSpawns(0.5f));       
    }

    IEnumerator CarregarSpawns(float tempoAEsperar)
    {
        objects = SpawnsFases[faseAtual].GetComponentsInChildren<Transform>();
        yield return new WaitForSeconds(tempoAEsperar);
        CriaZumbies(objects);
    }



    void Update()
    {
        if (faseAtual != Controlador.gm.faseAtual)
        {
            Start();
        }
    }

    void CriaZumbies(Transform[] spawns)
    {
        for (var i = 0; i < QtdInimigosFase[Controlador.gm.faseAtual]; i++)
        {
            int zumbie = Random.Range(1, inimigos.Length);
            Debug.Log("Fase atual: " + Controlador.gm.faseAtual);
            Debug.Log("Zombie Sorteado: " + zumbie);
            int posicao = Random.Range(0, spawns.Length);
            Controlador.gm.instanciarZumbie(inimigos[zumbie], spawns[posicao]);
        }

    }

}
