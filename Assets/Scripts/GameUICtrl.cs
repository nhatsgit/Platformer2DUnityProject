using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameUICtrl : MonoBehaviour
{
    public static GameUICtrl instance;

    [SerializeField] public GameObject moveUI;

    [SerializeField] public GameObject pauseButton;
    private Button pauseBtn;

    [SerializeField] public GameObject pauseGameUI;
    private Button restartBtn;
    private Button mainMenuBtn;
    private Button continueBtn;

    [SerializeField] public GameObject endGameUI;
    private Button restartBtn2;
    private Button mainMenuBtn2;
    private Button nextLevelBtn;
    private void Awake()
    {
        GameUICtrl.instance = this;
        OnStartGame();
        InitButton();
    }
    private void Start()
    {
        pauseBtn.onClick.AddListener(() => OnPause());
        restartBtn.onClick.AddListener(() => OnRestart());
        mainMenuBtn.onClick.AddListener(() => OnMainMenu());
        continueBtn.onClick.AddListener(() => OnContinue());
        restartBtn2.onClick.AddListener(() => OnRestart());
        mainMenuBtn2.onClick.AddListener(() => OnMainMenu());
        nextLevelBtn.onClick.AddListener(() => OnNextLevel());
    }

    private void OnContinue()
    {
        pauseButton.SetActive(true);
        pauseGameUI.SetActive(false);
    }

    private void OnStartGame()
    {
        pauseButton.SetActive(true);
        moveUI.SetActive(true);
        endGameUI.SetActive(false);
        pauseGameUI.SetActive(false);
    }
    private void InitButton()
    {
        pauseBtn = pauseButton.GetComponent<Button>();
        restartBtn = pauseGameUI.transform.Find("Restart").gameObject.GetComponent<Button>();
        mainMenuBtn = pauseGameUI.transform.Find("MainMenu").gameObject.GetComponent<Button>();
        continueBtn = pauseGameUI.transform.Find("Continue").gameObject.GetComponent<Button>();
        restartBtn2 = endGameUI.transform.Find("Restart").gameObject.GetComponent<Button>();
        mainMenuBtn2 = endGameUI.transform.Find("MainMenu").gameObject.GetComponent<Button>();
        nextLevelBtn = endGameUI.transform.Find("NextLevel").gameObject.GetComponent<Button>();

    }
    private void OnPause()
    {
        pauseButton.SetActive(false);
        pauseGameUI.SetActive(true);
    }
    private void OnRestart()
    {
        GameCtrl.instance.Restart();
    }
    private void OnMainMenu()
    {
        GameCtrl.instance.BackMenu();
    }
    private void OnNextLevel()
    {
        GameCtrl.instance.NextLevel();
    }    
}
