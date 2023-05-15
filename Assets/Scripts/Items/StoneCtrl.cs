using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCtrl : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
