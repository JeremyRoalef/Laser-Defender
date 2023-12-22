using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float fltSceneLoadDelay = 0.5f;

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("Game Over", fltSceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        //Application.Quit(); - won't work on webgl games
    }

    IEnumerator WaitAndLoad(string strSceneName, float fltDelay)
    {
        yield return new WaitForSeconds(fltDelay);
        SceneManager.LoadScene(strSceneName);
    }
}
