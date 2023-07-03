using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class gameManager : MonoBehaviour
{
    public int gameScore;
    public TMP_Text scoreText;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject startMenu;

    [SerializeField]
    public Spawner spawnerNotToWorkAtStart; //este spawner empezará desactivado y se activará una vez el usuario empiece a jugar

    bool gameIsPaused = false;
    public static bool juegoEnMarcha = false;

    //usadas en el bucle que devuelve gameScore como unidades, decenas...
    private int tmp;

    private void Update()
    {
        //pausa el juego si no está ya pausado
        if (Input.GetButtonDown("Pause") && gameOver.activeSelf == false && juegoEnMarcha == true)
        {
            if (gameIsPaused == true)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }

        //
        if (Input.GetButtonDown("Jump") && gameOver.activeSelf == true)
        {
            Reiniciar();
        }

        //activa el menú de pausa si juegoEnMarcha == false
        if (juegoEnMarcha == false)
        {
            startMenu.SetActive(true);
        }

        //Hace que el menú de pausa se quite si se pulsa el espacio
        if (Input.GetButtonDown("Jump") && juegoEnMarcha == false)
        {
            EmpezarAJugar();
        }

        //activa los spawners que se hayan de activar cuando el juego esté en marcha
        if (juegoEnMarcha == true)
        {
            spawnerNotToWorkAtStart.enabled = true;
        }

    }



    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        gameScore += scoreToAdd;

        scoreText.text = " ";

        for (int i = 10; i / 10 <= gameScore; i *= 10)
        {
            tmp = (gameScore % i - gameScore % (i / 10));
            Debug.Log(tmp.ToString()[0]);

            scoreText.text = "<sprite name=\"Num" + tmp.ToString()[0] + "\">" + scoreText.text;

        }
    }

    public void ResetScore()
    {

        gameScore = 0;

    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }

    public void Reanudar()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pausar()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Cerrar()
    {
        Debug.Log("APLICACIÓN CERRADA");
        Application.Quit();
    }

    public void EmpezarAJugar()
    {
        juegoEnMarcha = true;
        startMenu.SetActive(false);
    }
}