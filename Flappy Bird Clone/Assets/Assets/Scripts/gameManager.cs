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
    [SerializeField]
    GameObject gameOver;


    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        gameScore += scoreToAdd;

        scoreText.text = gameScore.ToString();
        //TODO: Hacer que la puntuación se divida en centenas, decenas y unidades para poder escribir bien los números con los sprite assets
        //https://stackoverflow.com/questions/26362388/split-number-into-hundreds-tens-and-units-using-c-sharp
    }

    public void ResetScore() {

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
}
