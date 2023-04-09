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
    private Toggle MobileModeToggle;

    [SerializeField] public GameObject endGameUI;
    private Button restartBtn2;
    private Button mainMenuBtn2;
    private Button nextLevelBtn;

    private String gameModeKey;
    private int gameModeValue;
    private bool isMobileMode;
    private void Awake()
    {
        GameUICtrl.instance = this;
        GetGameModeData();
        InitUI();
        OnStartGame();
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
        MobileModeToggle.onValueChanged.AddListener(delegate {OnGameModeChange(MobileModeToggle);});
    }
    private void GetGameModeData()
    {
        gameModeValue = PlayerPrefs.GetInt(gameModeKey, 1);
        if (gameModeValue == 1)
        {
            isMobileMode = true;
        }
        else
        {
            isMobileMode = false;
        }
    }
    private void OnContinue()
    {
        pauseButton.SetActive(true);
        pauseGameUI.SetActive(false);
    }

    private void OnStartGame()
    {
        pauseButton.SetActive(true);
        moveUI.SetActive(isMobileMode);
        endGameUI.SetActive(false);
        pauseGameUI.SetActive(false);
    }
    private void OnGameModeChange(Toggle change)
    {
        moveUI.SetActive(!moveUI.activeSelf);
        PlayerMove.instance.StatusChange_();
        PlayerMoveByButtons.instance_.StatusChange();
        gameModeValue = -gameModeValue;
        SaveGameMode();
    }
    private void InitUI()
    {
        pauseBtn = pauseButton.GetComponent<Button>();
        restartBtn = pauseGameUI.transform.Find("Restart").gameObject.GetComponent<Button>();
        mainMenuBtn = pauseGameUI.transform.Find("MainMenu").gameObject.GetComponent<Button>();
        continueBtn = pauseGameUI.transform.Find("Continue").gameObject.GetComponent<Button>();
        restartBtn2 = endGameUI.transform.Find("Restart").gameObject.GetComponent<Button>();
        mainMenuBtn2 = endGameUI.transform.Find("MainMenu").gameObject.GetComponent<Button>();
        nextLevelBtn = endGameUI.transform.Find("NextLevel").gameObject.GetComponent<Button>();
        MobileModeToggle = pauseGameUI.transform.Find("MobileMode").gameObject.GetComponent<Toggle>();
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
    private void SaveGameMode()
    {
        PlayerPrefs.SetInt(gameModeKey, gameModeValue);
        PlayerPrefs.Save();
    }
}
