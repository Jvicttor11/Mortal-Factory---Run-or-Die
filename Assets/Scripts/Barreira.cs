using System;   
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Barreira : MonoBehaviour
{
    public int portal;
    public KeyCode QuebrarBarreira = KeyCode.Tab;
    private bool podePassar = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colidindo: Portal " + portal);


        if (Controlador.gm.zumbisVivo == 0)
        {
            podePassar = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        podePassar = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && podePassar)
        {
            Controlador.gm.faseAtual = portal;
            Destroy(gameObject);
        }
    }
    void OnGUI()
    {
        if (podePassar)
        {
            GUIStyle stylez = new GUIStyle();
            stylez.alignment = TextAnchor.MiddleCenter;
            GUI.skin.label.fontSize = 20;
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 50, 200, 30), "Pressione: " + QuebrarBarreira);
        }
    }
}
