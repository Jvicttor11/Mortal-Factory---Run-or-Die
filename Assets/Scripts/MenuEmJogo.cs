using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEmJogo : MonoBehaviour
{
    bool isPausado=false;
    public GameObject TelaPause;
    public GameObject TelaFinal;
    public GameObject TelaGameOver;
    // Start is called before the first frame update
    void Start()
    {
        ZerarVisoes();
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPausado)
                PauseGame();
            else
                ResumeGame();
        }
    }

    void PauseGame()
    {
        TelaPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPausado = true;
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        TelaPause.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPausado = false;
        Time.timeScale = 1;
    }

    public void EndGame()
    {
        TelaFinal.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPausado = false;
        Time.timeScale = 1;
    }


    public void ZerarVisoes()
    {
        TelaFinal.SetActive(false);
        TelaPause.SetActive(false);
        TelaGameOver.SetActive(false);
    }

}
