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
    public AudioSource AudioSofrerDano;
    public AudioSource AudioParado;
    public AudioClip takeHitClip;
    public bool chefao = false;
    public int dano=10;



    private void Start()
    {
       // AudioSofrerDano.Play();
        podeAtacar = true;
        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        navMesh.destination = new Vector3(transform.position.x+Random.Range(0,5), transform.position.y + Random.Range(0, 5), transform.position.z+Random.Range(0, 5));
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

        if (Vector3.Distance(transform.position, player.transform.position) < 15f && vida > 0)
        {
            navMesh.destination = player.transform.position;
            anim.SetBool("parado", false);
            anim.SetBool("correndo", true);
        }
        else if (vida > 0)
        {

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


    public void SofrerDano(int dano)
    {
        Debug.Log("Atingido");
        //AudioSofrerDano.Play();
        AudioSofrerDano.PlayOneShot(takeHitClip, 1.0f);
        //AudioParado.PlayOneShot(takeHitClip);
        this.vida -= dano;
    }



    IEnumerator Morrer()
    {
        Debug.Log("Matando no inimigo");
        Controlador.gm.matarZombie(gameObject);
        anim.SetBool("morto", true);
        if (chefao)
        {
            Debug.Log("Chefão Morreu");
            yield return new WaitForSeconds(5);
            Controlador.gm.EndGame();
        }
        else
            yield return new WaitForSeconds(20);
        Destroy(gameObject);
    }

    IEnumerator AtacarPlayer()
    {
        podeAtacar = false;
        if(chefao)
        if (Vector3.Distance(transform.position, player.transform.position) < 15f && vida > 0)
        {
            player.GetComponent<FPSController>().dano(dano);

        }

        if (Vector3.Distance(transform.position, player.transform.position) < 10f && vida > 0)
        {
            player.GetComponent<FPSController>().dano(dano);

        }
        
        yield return new WaitForSeconds(1);
        podeAtacar = true;
    }
}
