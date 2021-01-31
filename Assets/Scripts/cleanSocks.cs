using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleanSocks : MonoBehaviour
{
    // Start is called before the first frame update
    // public int value = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collectablesManager.instance.cleanDirtySocks();
        }
    }
}
