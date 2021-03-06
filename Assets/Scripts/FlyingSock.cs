﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSock : MonoBehaviour
{
    private Rigidbody2D rb;
    public float flyspeed = 15;
    public Vector2 moveDirection = new Vector2(-1, 0);
    public AudioClip[] audio;
    public AudioSource randomSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        randomSound.clip = audio[Random.Range(0, audio.Length-1)];
        randomSound.Play();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.CompareTag("Solid")) {
            GameObject sock = (GameObject)Instantiate(Resources.Load("Prefabs/smellySock"));
            sock.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection.normalized * Time.deltaTime * flyspeed;
    }
}
