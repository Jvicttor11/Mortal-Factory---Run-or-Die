using UnityEngine;
using System.Collections;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Inimigo : MonoBehaviour
{

    public float vida = 100;
    bool chamouMorte = false;
    private bool podeAtacar = true;
    private Animator anim;
    private GameObject player;
    private NavMeshAgent navMesh;
    public string TagInimigo = "Player";

    private void Start()
    {
        
        podeAtacar = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
          
            Atacar();
        }
        else
        {
            anim.SetBool("attack", false);
        }
        
        if (Vector3.Distance(transform.position, player.transform.position) < 10f && vida > 0)
        {
            navMesh.destination = player.transform.position;
            anim.SetBool("parado", false);
            anim.SetBool("correndo",true);
        }
        else if(vida > 0) {
            anim.SetBool("correndo", false);
            anim.SetBool("parado", true);

        }

        if (vida <= 0)
        {
            vida = 0;
            if (chamouMorte == false)
            {
                anim.SetBool("correndo", false);
                anim.SetBool("parado", false);
                Morrer();
                chamouMorte = true;
                StartCoroutine("Morrer");
                

            }
        }
      
    }

    void Atacar()
    {
       anim.SetBool("parado", false);
       anim.SetBool("correndo", false);
       anim.SetBool("attack", true);
        if (podeAtacar == true)
        {
            StartCoroutine(AtacarPlayer());

        }
    }

    IEnumerator Morrer()
    {
        anim.SetBool("morto", true);
        yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    IEnumerator AtacarPlayer()
    {
        podeAtacar = false;

        if (Vector3.Distance(transform.position, player.transform.position) < 10f && vida > 0)
        {
            player.GetComponent<FPSController>().vida -= 5;

        }
        
        yield return new WaitForSeconds(1);
        podeAtacar = true;
    }
}