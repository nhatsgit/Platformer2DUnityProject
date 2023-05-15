using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameCtrl : MonoBehaviour
{
    public int levelID;
    public static GameCtrl instance;
    [SerializeField]private Animator transSceneAnim;
    
    private void Awake()
    {
        GameCtrl.instance = this;
    }
    public void Restart()
    {
        StartCoroutine(LoadScene(levelID));
    }
    public void NextLevel()
    {
        //transSceneAnim.SetTrigger("end");
        StartCoroutine(LoadScene(levelID+1));
    }
    IEnumerator LoadScene(int sceneID)
    {
        Time.timeScale = 1f;
        SoundManager.instance.OnStopSound();
        transSceneAnim.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneID);
    }
    public void BackMenu()
    {
        StartCoroutine(LoadScene(0));
    }
    public void EndGame()
    {
        if (PlayerPrefs.GetInt("CurrentLevel", 1) == levelID)
        {
            SaveLevelPassed();
        }
        Time.timeScale = 0f;
        GameUICtrl.instance.endGameUI.SetActive(true);
        GameUICtrl.instance.pauseButton.SetActive(false);
        GameUICtrl.instance.moveUI.SetActive(false);
    }
    private void SaveLevelPassed()
    {
        PlayerPrefs.SetInt("CurrentLevel", levelID+1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
