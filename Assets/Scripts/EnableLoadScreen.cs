using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLoadScreen : MonoBehaviour
{
    public GameObject enable;
    // Start is called before the first frame update
    public void Enable() {
        enable.gameObject.SetActive(true);
    }
}
