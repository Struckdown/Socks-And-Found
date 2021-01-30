using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameObject player;
    public int moveSpeed = 3;
    public Vector2 moveDirection;
    public float distanceToNoticePlayer = 5;
    private Vector2 spawnPoint;
    private Vector2 goalPoint;  // tries to go to this point if no player nearby
    public float leashRange = 10;    // how far the monster will randomly explore to
    public float wanderSpeed = 1;
    public float delayBeforeNextMovement; // how long the monster will wait before exploring to the next point
    private float timeElapsed = 0;
    private float timeReachGoal = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnPoint = transform.position;
        getNewGoalPoint();
        delayBeforeNextMovement = Random.Range(3, 6);
    }

    // Update is called once per frame
    void Update() {
        timeElapsed += Time.deltaTime;
        if ((player.transform.position - this.transform.position).magnitude < distanceToNoticePlayer)
        {
            // the player is within a radius of distanceToNoticePlayer units to this enemy

            moveDirection = player.transform.position - this.transform.position;
            //moveDirection = moveDirection.forward * Time.deltaTime;
            transform.Translate(moveDirection.normalized * Time.deltaTime * moveSpeed);
        }
        else
        { // Wander around randomly
            if (goalPoint != new Vector2(0, 0))
            {
                moveDirection = goalPoint - (Vector2)this.transform.position;
                if (moveDirection.magnitude < 0.1)
                {
                    goalPoint = new Vector2(0,0);
                    timeReachGoal = timeElapsed;
                }
                else
                {
                    transform.Translate(moveDirection.normalized * Time.deltaTime * wanderSpeed);
                }
            }
            else
            {
                if ((timeElapsed - timeReachGoal) > delayBeforeNextMovement)
                {
                    getNewGoalPoint();
                    delayBeforeNextMovement = Random.Range(3, 6);
                }
            }
        }
    }

    void getNewGoalPoint()
    {
        goalPoint = new Vector2(spawnPoint[0]+Random.Range(-leashRange / 2, leashRange / 2), spawnPoint[1]+Random.Range(-leashRange / 2, leashRange / 2));
        Debug.Log("GoalPoint:" + goalPoint);
        return;
    }
}
