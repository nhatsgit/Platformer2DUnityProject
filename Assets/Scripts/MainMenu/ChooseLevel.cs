using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{
    public static ChooseLevel instance;
    public int currentLevel ;
    private void Awake()
    {
        ChooseLevel.instance = this;
        currentLevel = PlayerPrefs.GetInt("CurrentLevel",1);       
    }
}
