using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<Target> targets;
    public float spawnTimeRate = 1;
    public TextMeshProUGUI scoreText,gameOverText;
    public Button restartButton;
    private int score;
    public bool isGameActive;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
    }

    IEnumerator SpawnTargetsRoutine()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnTimeRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Update is called once per frame
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score; 
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
        //gameOverText.text 
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        difficulty++;
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        scoreText.gameObject.SetActive(true);
        spawnTimeRate /= difficulty;
        Debug.Log(spawnTimeRate);
        StartCoroutine(SpawnTargetsRoutine());
        UpdateScore(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
