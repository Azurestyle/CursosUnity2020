using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {   
        loading,
        inGame,
        gameOver
    }

    private AudioSource _audioSource;
    public AudioClip audioPlop;
    public GameObject titleScreen;
    private int numberOfLives = 4;
    public List<GameObject> lives;
    public GameState gameState;
    public List<GameObject> targetPrefabs;
    public TextMeshProUGUI gameOverText;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;
    private int _score;
    private int score
    {
        set
        {    // si es - 0 pones 0 y si no pones el valor
            _score = Mathf.Max(value, 0);
        }
        get
        {
            return _score;
        }
    }

    public Button restartButton;
   
    /// <summary>
    /// Método que inicia la partida cambiando el valor del estado del juego
    /// </summary>
    /// <param name="difficulty">Número entero que indica el grado de dificultad del juego</param>
    public void StartGame(int difficulty)
    {   
        
        gameState = GameState.inGame;
        titleScreen.gameObject.SetActive(false);
        spawnRate /= difficulty;  // lo mismo que spawnrate = spawnrate/difficulty
        numberOfLives -= difficulty; // para restar vidas según la dificultad
        for (int i = 0; i < numberOfLives; i++)
        {
            lives[i].SetActive(true);
        }
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        ShowMaxScore();
    }

    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }

    /// <summary>
    /// Actualizar la puntuación y muestra por pantalla
    /// </summary>
    /// <param name="scoreToAdd">Número de puntos a añadir a la puntuación global</param>
    public void UpdateScore(int scoreToAdd)
    {
        if (scoreToAdd!=0)
        {
            _audioSource.PlayOneShot(audioPlop,1f);
        }
        
        score += scoreToAdd;
        scoreText.text = "Score: \n " + score;
    }

    private const string MAX_SCORE = "MAX_SCORE";
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0); // el 0 es el valor por defecto si no existe max_score
        scoreText.text = "Score: \n" + maxScore;
    }

    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
            
            //TODO: si hay nueva puntuación máxima lanzar cohetes
        }
    }
    public void GameOver()
    {
        numberOfLives--;
        if (numberOfLives >=0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f; //alpha para que sea transparente
            heartImage.color = tempColor;
        }
       
        if (numberOfLives<=0)
        {
            SetMaxScore();
            gameOverText.gameObject.SetActive(true);
            gameState = GameState.gameOver;
            restartButton.gameObject.SetActive(true);
        }
       
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
