using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameObject player;
    public int moveSpeed = 10;
    public Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
        if (true) {//((player.transform.position-this.transform.position).sqrMagnitude<3*3) {
            // the player is within a radius of 3 units to this enemy

            // moveDirection = player.transform.position - this.transform.position;
            //moveDirection = moveDirection.forward * Time.deltaTime;
            transform.Translate(moveDirection.normalized * Time.deltaTime * moveSpeed);
        }
    }

}
