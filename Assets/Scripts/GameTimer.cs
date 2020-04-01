using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{   
    [Tooltip("Level timer in SECONDS.")]
    [SerializeField] float baseLevelTime = 60;
    [SerializeField] AttackerSpawner[] attackerSpawners;
    [SerializeField] float spawnDelay;
    float levelTime;
    bool triggeredLevelFinished = false;

    private void Start()
    {
        SetLevelTimer(PlayerPrefsController.GetMasterDifficulty());
        StartCoroutine(StartSpawners());
    }

    private void SetLevelTimer(float masterDifficulty)
    {
        levelTime = baseLevelTime - (masterDifficulty * 10); 
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;

        }
    }

    IEnumerator StartSpawners()
    {
        yield return new WaitForSeconds(spawnDelay);
        foreach(AttackerSpawner spawner in attackerSpawners)
        {
            spawner.gameObject.SetActive(true);
        }
    }

}
