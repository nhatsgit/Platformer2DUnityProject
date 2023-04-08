using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUICtrler : MonoBehaviour
{
    //public static StartUICtrler instance;
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject chooseLV;
    [SerializeField] private GameObject settingUI;
    private Button playButton;
    private Button settingButton;
    private Button quitButton;
    private Button backSettingBtn;
    private Button backChooseLVBtn;
    //[SerializeField] private Toggle consoleMode;
    //[SerializeField] private Toggle mobileMode;



    private void Awake()
    {
       // StartUICtrler.instance = this;
        startUI.SetActive(true);
        chooseLV.SetActive(false);
        settingUI.SetActive(false);
        InitButton();
    }
    private void Start()
    {
        OnPlay();
        OnSetting();
        OnBackChooseLV();
        OnBackSetting();
        quitButton.onClick.AddListener(() => GameCtrl.instance.Quit());
    }
    private void InitButton()
    {
        playButton = startUI.transform.Find("Play").gameObject.GetComponent<Button>();
        settingButton = startUI.transform.Find("Setting").gameObject.GetComponent<Button>();
        quitButton = startUI.transform.Find("Quit").gameObject.GetComponent<Button>();
        backChooseLVBtn = chooseLV.transform.Find("Back").gameObject.GetComponent<Button>();
        backSettingBtn = settingUI.transform.Find("Back").gameObject.GetComponent<Button>();
    }
    private void OnPlay()
    {
        playButton.onClick.AddListener(() => chooseLV.SetActive(true));
        playButton.onClick.AddListener(() => startUI.SetActive(false));
    }
    private void OnSetting()
    {
        settingButton.onClick.AddListener(() => settingUI.SetActive(true));
        settingButton.onClick.AddListener(() => startUI.SetActive(false));
    }
    private void OnBackSetting()
    {
        backSettingBtn.onClick.AddListener(() => settingUI.SetActive(false));
        backSettingBtn.onClick.AddListener(() => startUI.SetActive(true));
    }
    private void OnBackChooseLV()
    {
        backChooseLVBtn.onClick.AddListener(() => chooseLV.SetActive(false));
        backChooseLVBtn.onClick.AddListener(() => startUI.SetActive(true));
    }
}
