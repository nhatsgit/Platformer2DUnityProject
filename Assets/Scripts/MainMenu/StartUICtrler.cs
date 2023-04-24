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
    public AudioSource clickSound;


    private void Awake()
    {
        //StartUICtrler.instance = this;
        startUI.SetActive(true);
        chooseLV.SetActive(false);
        settingUI.SetActive(false);
        InitButton();
    }
    private void Start()
    {
        playButton.onClick.AddListener(OnPlay);
        settingButton.onClick.AddListener(OnSetting);
        backSettingBtn.onClick.AddListener(OnBackSetting);
        backChooseLVBtn.onClick.AddListener(OnBackChooseLV);
        quitButton.onClick.AddListener(() => Application.Quit());
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
        clickSound.Play();
        chooseLV.SetActive(true);
        startUI.SetActive(false);
    }
    private void OnSetting()
    {
        clickSound.Play();
        settingUI.SetActive(true);
        startUI.SetActive(false);
    }
    private void OnBackSetting()
    {
        clickSound.Play();
        settingUI.SetActive(false);
        startUI.SetActive(true);
    }
    private void OnBackChooseLV()
    {
        clickSound.Play();
        chooseLV.SetActive(false);
        startUI.SetActive(true);
    }
}
