using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Transform grabObjectTranform;
    private int currentOption = 0;
    private void Awake()
    {
        LoadData();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
    }
    private void Start()
    {
        UpdatePlayer(currentOption);
    }
    private void UpdatePlayer(int currentOption)
    {
        spriteRenderer.sprite = characterDatabase.GetCharacter(currentOption).sprite;
        animator.runtimeAnimatorController= characterDatabase.GetCharacter(currentOption).animation;
        grabObjectTranform.localPosition= characterDatabase.GetCharacter(currentOption).grabPos;
    }
    private void LoadData()
    {
        currentOption = PlayerPrefs.GetInt("CurrentOption");
    }
}
