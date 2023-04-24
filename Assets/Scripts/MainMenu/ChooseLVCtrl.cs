using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ChooseLVCtrl : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private TMP_Text text;
    private Button chooseLVBtn;

    private void Awake()
    {
        text.text = "Level" + level;
        chooseLVBtn=this.GetComponent<Button>();
    }
    private void Start()
    {
        chooseLVBtn.onClick.AddListener(LoadLever);
    }
    public void LoadLever()
    {
        SceneManager.LoadScene(level);
    }
}
