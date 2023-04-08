using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameCtrl : MonoBehaviour
{
    public int scene;
    public static GameCtrl instance;
    private void Awake()
    {
        GameCtrl.instance = this;
    }
    public void Restart()
    {
        SceneManager.LoadScene(scene);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(scene + 1);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void EndGame()
    {
        Time.timeScale = 0f;
        GameUICtrl.instance.endGameUI.SetActive(true);
        GameUICtrl.instance.pauseButton.SetActive(false);
        GameUICtrl.instance.moveUI.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
