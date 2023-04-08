using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPointCtrl : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameCtrl.instance.EndGame();
    }
    
}
