using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introducao : MonoBehaviour
{

    void Start()
    {
        this.PularIntroducao(72);

    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Fase1");
        }
    }

    IEnumerator PularIntroducao(float tempoAEsperar)
    {
        yield return new WaitForSeconds(tempoAEsperar);
        SceneManager.LoadScene("Fase1");
    }
}
