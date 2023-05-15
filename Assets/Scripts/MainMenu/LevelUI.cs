using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelUI : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private TMP_Text text;
    private Button chooseLVBtn;

    private void Awake()
    {
        chooseLVBtn = this.GetComponent<Button>();
    }
    private void Start()
    {
        if (level <= ChooseLevel.instance.currentLevel)
        {
            text.text = "Level" + level;
        }
        else
        {
            text.text = "lock";
            chooseLVBtn.enabled = false;
        }
        chooseLVBtn.onClick.AddListener(LoadLever);
    }
    public void LoadLever()
    {
        SceneManager.LoadScene(level);
    }
}
