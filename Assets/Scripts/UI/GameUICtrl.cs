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

    private String gameModeKey="gameModeKey";
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
        PlayerMove.instance.StatusChange_(isMobileMode);
        PlayerMoveByButtons.instance_.StatusChange(isMobileMode);
        pauseBtn.onClick.AddListener(() => OnPause());
        restartBtn.onClick.AddListener(() => OnRestart());
        mainMenuBtn.onClick.AddListener(() => OnMainMenu());
        continueBtn.onClick.AddListener(() => OnContinue());
        restartBtn2.onClick.AddListener(() => OnRestart());
        mainMenuBtn2.onClick.AddListener(() => OnMainMenu());
        nextLevelBtn.onClick.AddListener(() => OnNextLevel());
        MobileModeToggle.onValueChanged.AddListener(delegate {OnGameModeChange(MobileModeToggle);});
    }
    
    private void OnContinue()
    {
        pauseButton.SetActive(true);
        pauseGameUI.SetActive(false);
        SoundManager.instance.OnPlaySound(SoundType.click);
    }

    private void OnStartGame()
    {
        SoundManager.instance.OnPlaySound(SoundType.click);
        pauseButton.SetActive(true);
        moveUI.SetActive(isMobileMode);
        MobileModeToggle.isOn= isMobileMode;
        endGameUI.SetActive(false);
        pauseGameUI.SetActive(false);
    }
    private void OnGameModeChange(Toggle change)
    {
        moveUI.SetActive(!moveUI.activeSelf);
        PlayerMove.instance.StatusChange_(moveUI.activeSelf);
        PlayerMoveByButtons.instance_.StatusChange(moveUI.activeSelf);
        gameModeValue = -gameModeValue;
        SaveGameMode();
        isMobileMode = (gameModeValue == 1);

    }
    private void GetGameModeData()
    {
        gameModeValue = PlayerPrefs.GetInt(gameModeKey, 1);
        isMobileMode=(gameModeValue == 1);
    }
    private void SaveGameMode()
    {
        PlayerPrefs.SetInt(gameModeKey, gameModeValue);
        PlayerPrefs.Save();
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
        SoundManager.instance.OnPlaySound(SoundType.click);
        pauseButton.SetActive(false);
        pauseGameUI.SetActive(true);
        isMobileMode = (gameModeValue == 1);
    }
    private void OnRestart()
    {
        GameCtrl.instance.Restart();
        isMobileMode = (gameModeValue == 1);
    }
    private void OnMainMenu()
    {
        GameCtrl.instance.BackMenu();
        isMobileMode = (gameModeValue == 1);
    }
    private void OnNextLevel()
    {
        GameCtrl.instance.NextLevel();
        isMobileMode = (gameModeValue == 1);
    }

}
