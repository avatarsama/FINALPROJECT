using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public UnityEngine.UI.Text ScoreText;
    public UnityEngine.UI.Text gameOverText;
    public UnityEngine.UI.Text restartText;
    public UnityEngine.UI.Text speedText;

    public UnityEngine.UI.Text winText;
    private bool gameOver;
    private bool restart;
    public int score;
 

    public AudioSource musicSource1;
    public AudioClip musicClip1;
    public AudioClip musicClip2;
    public AudioClip musicClip3;

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        speedText.text = "";
        gameOverText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        musicSource1.clip = musicClip1;
        musicSource1.Play();
    }

    
    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Time.timeScale = 2f;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1f;
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x),
                      spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Space' to Restart";
                speedText.text = "Press 'H' While Playing for 'Space Rush' Mode " +
                    "and 'R' to Return to Normal!";
                restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
  

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
        {
            winText.text = "You win! Game created by Samantha Barrizonte!";
            gameOver = true;
            restart = true;
            Destroy(GameObject.FindWithTag("Player"));
            musicSource1.clip = musicClip1;
            musicSource1.Stop();
            musicSource1.clip = musicClip2;
            musicSource1.Play();
  
        }
    }

    public void GameOver()
    {
            gameOverText.text = "Game Over!";
            gameOver = true;
            musicSource1.clip = musicClip1;
            musicSource1.Stop();
            musicSource1.clip = musicClip3;
            musicSource1.Play();
    }
}
