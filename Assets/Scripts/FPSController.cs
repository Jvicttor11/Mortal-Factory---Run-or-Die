using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{

    public float speed = 6.0f;
    public float vida = 100;
    public float jump = 6.0f;
    GameObject cameraFPS;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    float rotacaoX = 0.0f, rotacaoY = 0.0f;
    public AudioSource AudioAndar;
    public AudioSource AudioPular;
    public AudioSource AudioDano;

    private bool sofrendoDano = false;

    public Text Vida;
    private Vector3 currentAngle;
    public Vector3 targetAngle;
    void Start()
    {
        transform.tag = "Player";
        cameraFPS = transform.gameObject;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        if (vida < 0)
        {

            Vida.text = "Vida: 0 ";

            float speed = 0.1f;

            Quaternion target = Quaternion.Euler(-66, cameraFPS.transform.rotation.y, cameraFPS.transform.rotation.z);

            cameraFPS.transform.rotation = Quaternion.Lerp(cameraFPS.transform.rotation, target, Time.time * speed);

            Controlador.gm.Morte();
        }
        else
        {

            Vida.text = "Vida: " + vida;



            Vector3 direcaoFrente = new Vector3(cameraFPS.transform.forward.x, 0, cameraFPS.transform.forward.z);
            Vector3 direcaoLado = new Vector3(cameraFPS.transform.right.x, 0, cameraFPS.transform.right.z);
            direcaoFrente.Normalize();
            direcaoLado.Normalize();
            direcaoFrente = direcaoFrente * Input.GetAxis("Vertical");
            direcaoLado = direcaoLado * Input.GetAxis("Horizontal");
            Vector3 direcFinal = direcaoFrente + direcaoLado;
            if (direcFinal.sqrMagnitude > 1)
            {
                if (!AudioAndar.isPlaying)
                    AudioAndar.Play();
                direcFinal.Normalize();
            }

            if (controller.isGrounded)
            {
                moveDirection = new Vector3(direcFinal.x, 0, direcFinal.z);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                {
                    if (!AudioPular.isPlaying)
                    {
                        AudioAndar.Stop();
                        AudioPular.Play();
                    }
                    moveDirection.y = jump;
                }
            }

            moveDirection.y -= 20.0f * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            CameraPrimeiraPessoa();
        }
    }

    public void dano(int dano)
    {
        if (!sofrendoDano)
        {
            sofrendoDano = true;
            AudioDano.Play();
            Aguardar(2);
            sofrendoDano = false;
        }

        vida -= dano;
    }

    IEnumerator Aguardar(float tempoAEsperar)
    {
        yield return new WaitForSeconds(tempoAEsperar);

    }

    void CameraPrimeiraPessoa()
    {
        rotacaoX += Input.GetAxis("Mouse X") * 10.0f;
        rotacaoY += Input.GetAxis("Mouse Y") * 10.0f;
        rotacaoX = ClampAngleFPS(rotacaoX, -360, 360);
        rotacaoY = ClampAngleFPS(rotacaoY, -80, 80);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotacaoX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotacaoY, -Vector3.right);
        Quaternion rotacFinal = Quaternion.identity * xQuaternion * yQuaternion;
        cameraFPS.transform.localRotation = Quaternion.Lerp(cameraFPS.transform.localRotation, rotacFinal, Time.deltaTime * 10.0f);
    }

    float ClampAngleFPS(float angulo, float min, float max)
    {
        if (angulo < -360)
        {
            angulo += 360;
        }
        if (angulo > 360)
        {
            angulo -= 360;
        }
        return Mathf.Clamp(angulo, min, max);
    }




}




