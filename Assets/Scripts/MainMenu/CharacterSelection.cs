using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    public Image spriteRenderer;
    private int currentOption=0;
    public Button nextOption;
    public Button prevOption;
    public AudioSource clickSound;
    private void Awake()
    {
        LoadData();
    }
    private void Start()
    {
        UpdateCharactacter(currentOption);
        prevOption.onClick.AddListener(()=> PrevOption());
        nextOption.onClick.AddListener(() => NextOption());
    }
    private void NextOption()
    {
        clickSound.Play();
        currentOption++;
        if (currentOption>= characterDatabase.CharacterCount)
        {
            currentOption = 0;
        }
        UpdateCharactacter(currentOption);
        SaveData();
    }
    private void PrevOption()
    {
        clickSound.Play();
        currentOption--;
        if (currentOption < 0)
        {
            currentOption = characterDatabase.CharacterCount-1;
        }
        UpdateCharactacter(currentOption);
        SaveData();
    }
    private void UpdateCharactacter(int currentOption)
    {
        Sprite sprite_ = characterDatabase.GetCharacter(currentOption).sprite;
        spriteRenderer.sprite = sprite_;

    }
    private void SaveData()
    {
        PlayerPrefs.SetInt("CurrentOption", currentOption);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        currentOption = PlayerPrefs.GetInt("CurrentOption");
    }
}
