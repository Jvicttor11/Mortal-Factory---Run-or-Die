using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEmJogo : MonoBehaviour
{
    bool isPausado=false;
    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPausado)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPausado = true;
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

}
