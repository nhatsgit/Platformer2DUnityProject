using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField] private Transform keyPos;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.OnPlaySound(SoundType.collect);
            gameObject.transform.parent = keyPos;
            gameObject.transform.position = keyPos.position;
            if (other.transform.localRotation.y==-1)
            {
                transform.localRotation = Quaternion.Euler(0, -180, -105);
            }
        }else if (other.gameObject.CompareTag("Door"))
        {
            SoundManager.instance.OnPlaySound(SoundType.opendoor);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

    }
    
}
