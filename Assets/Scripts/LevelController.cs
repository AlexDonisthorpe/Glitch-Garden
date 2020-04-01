using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject levelEndCanvas;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float winDelayInSeconds = 10f;
    private int enemyCounter = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        levelEndCanvas.SetActive(false);
    }

    public void IncreaseEnemyCounter()
    {
        enemyCounter++;
    }

    public void DecreaseEnemyCounter()
    {
        enemyCounter--;
        if(enemyCounter <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        levelEndCanvas.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelayInSeconds);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        levelEndCanvas.SetActive(true);
        winText.SetActive(false);
        gameOverText.SetActive(true);
        FindObjectOfType<LevelLoader>().LoadGameOverScene();
    }
}
