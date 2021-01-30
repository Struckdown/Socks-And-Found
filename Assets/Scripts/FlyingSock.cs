using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSock : MonoBehaviour
{
    private Rigidbody2D rb;
    public float flyspeed = 15;
    public Vector2 moveDirection = new Vector2(-1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = moveDirection.normalized * Time.deltaTime * flyspeed;
    }
}
