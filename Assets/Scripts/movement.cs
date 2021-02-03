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

    public Animator animator;
    public AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        // flips player
        // if (moveInputHorizontal > 0) {
        //     transform.eulerAngles = new Vector3(0, 0, 0);
        // }
        // else if (moveInputHorizontal < 0) {
        //     transform.eulerAngles = new Vector3(0, 180, 0);
        // }
    }
    void FixedUpdate() {
        // movement
        moveInputHorizontal = Input.GetAxisRaw("Horizontal");
        moveInputVertical = Input.GetAxisRaw("Vertical");

        if (moveInputHorizontal > 0)
        {
            animator.SetInteger("state", 3);
        }
        else if (moveInputHorizontal < 0)
        {
            animator.SetInteger("state", 1);
        }
        else if (moveInputVertical > 0)
        {
            animator.SetInteger("state", 2);
        }
        else if (moveInputVertical < 0)
        {
            animator.SetInteger("state", 4);
        }
        else
        {
            animator.SetInteger("state", 0);
        }

        if (moveInputHorizontal != 0 || moveInputVertical != 0)
        {
            footsteps.mute = false;
        }
        else
        {
            footsteps.mute = true;
        }
        

        rb.velocity = new Vector2(moveInputHorizontal * speed, moveInputVertical * speed);
    }
}
