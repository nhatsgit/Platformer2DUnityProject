using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverCtrl : MonoBehaviour
{
    [SerializeField] private GameObject leverButton;
    [SerializeField] private GameObject Collumn;
    private Button leverBtn;
    private bool onLever;
    private void Awake()
    {
        leverButton.SetActive(false);
        onLever = false;
        leverBtn=leverButton.GetComponent<Button>();
    }
    private void Start()
    {
        leverBtn.onClick.AddListener(()=>OnLeverDestroy());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && onLever)
        {
            OnLeverDestroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverButton.SetActive(true);
            onLever=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            leverButton.SetActive(false);
            onLever=false;
        }
    }
    public void OnLeverDestroy()
    {
        SoundManager.instance.OnPlaySound(SoundType.opendoor2);
        if (Collumn == null) return;
        Collumn.GetComponent <Collider2D>().isTrigger=true;
        Invoke("DestroyCollumn", 2);
    }
    private void DestroyCollumn()
    {
        Destroy(Collumn);
        SoundManager.instance.OnStopSound();
    }
}
