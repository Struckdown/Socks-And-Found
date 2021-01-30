using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // speeds
    public float speed = 5f;

    // horizontal mouse move
    private float moveInputHorizontal;
    private float moveInputVertical;
    
    // inits rigid body
    private Rigidbody2D rb;

    // public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // flips player
        if (moveInputHorizontal > 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInputHorizontal < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void FixedUpdate() {
        // movement
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");

        // animator.SetFloat("HorizontalMovement", moveInputHorizontal);
        // animator.SetFloat("VerticalMovement", moveInputVertical);
        

        rb.velocity = new Vector2(moveInputHorizontal * speed, moveInputVertical * speed);
    }
}
