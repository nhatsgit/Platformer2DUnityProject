using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            this.GetComponent<Animator>().SetTrigger("Die");
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            SoundManager.instance.OnPlaySound(SoundType.collect);
            StartCoroutine(RestartGame());
        }
    }
    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(0.5f);
        GameCtrl.instance.Restart();
    }
}
