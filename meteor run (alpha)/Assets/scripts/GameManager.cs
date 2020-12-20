using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titlepanel;
    public GameObject restartpanel;
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI scoreText;
    public List<GameObject> meteors;
    public List<GameObject> coin;
    public bool isGameActive = true;
    private float spawnRate = 1.0f;
    private float spawnRate2 = 0.5f;
    private int score;
    public Button restartButton;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {

        
        

    }

    // Update is called once per frame
    void Update()
    {
    if(score > 200)
        {
            canMove = false;
            restartpanel.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
            isGameActive = false;
           
        }
    }

    public void GameOver()
    {
        restartpanel.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        
        isGameActive = false;
    }

    IEnumerator SpawnMeteor()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, meteors.Count);
            Instantiate(meteors[index]);
        }
    }

    IEnumerator SpawnCoin()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate2);
            int index = Random.Range(0, coin.Count);
            Instantiate(coin[index]);
           
        }
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        canMove = true;
        StartCoroutine(SpawnMeteor());
        StartCoroutine(SpawnCoin());
        titleScreen.gameObject.SetActive(false);
        titlepanel.gameObject.SetActive(false);
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    
}
