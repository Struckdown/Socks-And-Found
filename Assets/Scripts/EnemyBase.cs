using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameObject player;
    public int moveSpeed = 3;
    public Vector2 moveDirection;
    public float distanceToNoticePlayer = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if ((player.transform.position-this.transform.position).magnitude < distanceToNoticePlayer) {
            // the player is within a radius of 3 units to this enemy

            moveDirection = player.transform.position - this.transform.position;
            //moveDirection = moveDirection.forward * Time.deltaTime;
            transform.Translate(moveDirection.normalized * Time.deltaTime * moveSpeed);
        }
    }

}
