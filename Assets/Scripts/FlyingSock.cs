using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSock : MonoBehaviour
{
    private Rigidbody2D rb;
    public float flyspeed = 3;
    public Vector2 moveDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDirection.normalized * Time.deltaTime * flyspeed;
    }
}
