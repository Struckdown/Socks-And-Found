using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wait : MonoBehaviour
{
    public int waitTime = 6;
    public GameObject enable;
    private float timeStart;
    void Start()
    {
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= waitTime + timeStart){
            enable.gameObject.SetActive(true);
        }
    }
}
