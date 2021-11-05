using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public bool movimentando=false;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", movimentando);
    }
}
