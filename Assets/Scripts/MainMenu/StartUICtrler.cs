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
    private Slider volumeBar;
    //[SerializeField] private Toggle mobileMode;


    private void Awake()
    {
        //StartUICtrler.instance = this;
        startUI.SetActive(true);
        chooseLV.SetActive(false);
        settingUI.SetActive(false);
        InitUI();
    }
    private void Start()
    {
        playButton.onClick.AddListener(OnPlay);
        settingButton.onClick.AddListener(OnSetting);
        backSettingBtn.onClick.AddListener(OnBackSetting);
        backChooseLVBtn.onClick.AddListener(OnBackChooseLV);
        quitButton.onClick.AddListener(() => Application.Quit());
        volumeBar.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        volumeBar.value = PlayerPrefs.GetFloat("Volume",1);
    }
    private void InitUI()
    {
        playButton = startUI.transform.Find("Play").gameObject.GetComponent<Button>();
        settingButton = startUI.transform.Find("Setting").gameObject.GetComponent<Button>();
        quitButton = startUI.transform.Find("Quit").gameObject.GetComponent<Button>();
        backChooseLVBtn = chooseLV.transform.Find("Back").gameObject.GetComponent<Button>();
        backSettingBtn = settingUI.transform.Find("Back").gameObject.GetComponent<Button>();
        volumeBar= settingUI.transform.Find("VolumeBar").gameObject.GetComponent<Slider>();
    }
    private void OnPlay()
    {
        SoundManager.instance.OnPlaySound(SoundType.click);
        //clickSound.Play();
        chooseLV.SetActive(true);
        startUI.SetActive(false);
    }
    private void OnSetting()
    {
        SoundManager.instance.OnPlaySound(SoundType.click);
        settingUI.SetActive(true);
        startUI.SetActive(false);
    }
    private void OnBackSetting()
    {
        SoundManager.instance.OnPlaySound(SoundType.click);
        settingUI.SetActive(false);
        startUI.SetActive(true);
    }
    private void OnBackChooseLV()
    {
        SoundManager.instance.OnPlaySound(SoundType.click);
        chooseLV.SetActive(false);
        startUI.SetActive(true);
    }
    private void OnVolumeChange()
    {
        SoundManager.instance.OnSoundVolumeChange(volumeBar.value);
        MusicManager.instance.OnMusicVolumeChange(volumeBar.value);
        PlayerPrefs.SetFloat("Volume", volumeBar.value);
    }
}
