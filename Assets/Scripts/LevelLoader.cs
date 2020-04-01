using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 3;
    int currentSceneIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForSceneLoad(currentSceneIndex+1));
        }
    }

    IEnumerator WaitForSceneLoad(int sceneIndexToLoad)
    {
        yield return new WaitForSeconds(loadDelay);
        LoadScene(sceneIndexToLoad);
    }

    private void LoadScene(int sceneIndexToLoad)
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);    
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitForSceneLoad(SceneManager.sceneCountInBuildSettings-1));
        Time.timeScale = 1;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
