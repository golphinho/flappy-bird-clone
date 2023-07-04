using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int gameScore;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    [SerializeField]
    GameObject gameOver;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject startMenu;

    [SerializeField] Animator wingsAnimator;

    [SerializeField]
    public Spawner spawnerNotToWorkAtStart; //este spawner empezar� desactivado y se activar� una vez el usuario empiece a jugar

    bool gameIsPaused = false;
    public static bool juegoEnMarcha = false;

    //usadas en el bucle que devuelve gameScore como unidades, decenas...
    private int tmp;

    private void Start()
    {
        wingsAnimator.SetBool("isDead", false);

        scoreText.text = string.Empty;
        bestScoreText.text = string.Empty;

        scoreText.text = "<sprite name=\"Num0\">"; //establece el n�mero mostrado con la puntuaci�n del jugador en 0 siempre que se inicie el juego
        
        //hace que en la pantalla se muestre, al empezar, la mejor puntuaci�n del usuario (sin esto saldr�a un 0 hasta que el jugador subiese su puntuaci�n)
        for (int i = 10; i / 10 <= PlayerPrefs.GetInt("bestScore"); i *= 10)
        {
            tmp = (PlayerPrefs.GetInt("bestScore") % i - PlayerPrefs.GetInt("bestScore") % (i / 10));
            Debug.Log(tmp.ToString()[0]);

            bestScoreText.text = "<sprite name=\"Num" + tmp.ToString()[0] + "\">" + bestScoreText.text;
        }

        FindObjectOfType<AudioManager>().Play("Music");
    }

    private void Update()
    {
        //pausa el juego si no est� ya pausado
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

        //activa el men� de pausa si juegoEnMarcha == false
        if (juegoEnMarcha == false)
        {
            startMenu.SetActive(true);
        }

        //Hace que el men� de pausa se quite si se pulsa el espacio o pulsa en la pantalla
        if (Input.GetButtonDown("Jump") && juegoEnMarcha == false || Input.GetMouseButtonDown(0) && juegoEnMarcha == false)
        {
            EmpezarAJugar();
        }

        //activa los spawners que se hayan de activar cuando el juego est� en marcha
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
        bestScoreText.text = " ";

        //separa la puntuaci�n del jugador en centenas, decenas y unidades para poder mostrarla correctamente con los sprites correspondientes en la pantalla.
        for (int i = 10; i / 10 <= gameScore; i *= 10)
        {
            tmp = (gameScore % i - gameScore % (i / 10));
            Debug.Log(tmp.ToString()[0]);

            scoreText.text = "<sprite name=\"Num" + tmp.ToString()[0] + "\">" + scoreText.text;

        }

        //Guarda el valor de la puntuaci�n del jugador en bestScore si es la mejor puntuaci�n que ha obtenido. Como bestScore es un PlayerPref, se guarda tras cerrar el juego.
        if (gameScore > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", gameScore);
            Debug.Log("BESTO SCORE: " + PlayerPrefs.GetInt("bestScore"));
        }

        for (int i = 10; i / 10 <= PlayerPrefs.GetInt("bestScore"); i *= 10)
        {
            tmp = (PlayerPrefs.GetInt("bestScore") % i - PlayerPrefs.GetInt("bestScore") % (i / 10));
            Debug.Log(tmp.ToString()[0]);

            bestScoreText.text = "<sprite name=\"Num" + tmp.ToString()[0] + "\">" + bestScoreText.text;
        }
    }

    public void ResetScore()
    {

        gameScore = 0;

    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        wingsAnimator.SetBool("isDead", true);
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
        Debug.Log("APLICACI�N CERRADA");
        Application.Quit();
    }

    public void EmpezarAJugar()
    {
        juegoEnMarcha = true;
        startMenu.SetActive(false);
    }
}