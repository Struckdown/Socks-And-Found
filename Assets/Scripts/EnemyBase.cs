using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private GameObject player;
    public int moveSpeed = 3;
    public Vector2 moveDirection;
    public float acceleration = 5f;
    private float v;    //velocity
    public float maxSpeed = 3;
    public int damage = 1;
    public int health = 5;

    private Rigidbody2D rb;
    public AudioClip[] audio;
    public AudioSource randomSound;
    public AudioClip[] hurtAudio;
    public Animator animator;

    //Wander logic
    public float distanceToNoticePlayer = 5;
    private Vector2 spawnPoint;
    private Vector2 goalPoint;  // tries to go to this point if no player nearby
    public float leashRange = 10;    // how far the monster will randomly explore to
    public float wanderSpeed = 2;
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
        rb = GetComponent<Rigidbody2D>();

        Invoke("emitRandomSound", Random.Range(7, 12));
    }

    void emitRandomSound()
    {
        AudioSource.PlayClipAtPoint(audio[Random.Range(0, audio.Length)], this.gameObject.transform.position);
        Invoke("emitRandomSound", Random.Range(7, 12));
    }
    // Update is called once per frame
    void Update() {
        timeElapsed += Time.deltaTime;

        // check if the player is within a radius of distanceToNoticePlayer units to this enemy
        if ((player.transform.position - this.transform.position).magnitude < distanceToNoticePlayer)
        {
            moveTowardsPlayer();
        }
        else
        { // Wander around randomly
            wander();
        }
    }

    void getNewGoalPoint()
    {
        goalPoint = new Vector2(spawnPoint[0]+Random.Range(-leashRange / 2, leashRange / 2), spawnPoint[1]+Random.Range(-leashRange / 2, leashRange / 2));
        return;
    }

    void bumpPlayer()
    {
        Vector2 distanceVector = player.transform.position - this.transform.position;
        v = distanceVector.magnitude * -100;

        return;
    }

    void moveTowardsPlayer()
    {

        float timeToStop = v / acceleration;
        Vector2 distanceVector = player.transform.position - this.transform.position;
        float distance = distanceVector.magnitude;
        float decelDistance = v * v / (2 * acceleration);

        float angle = Mathf.Atan2(distanceVector[1], distanceVector[0]);
        float cosangle = Mathf.Cos(angle);
        float sinangle = Mathf.Sin(angle);


        if (distance > decelDistance) //we are still far, continue accelerating (if possible)
        {
            v = Mathf.Min(v + acceleration * Time.deltaTime, maxSpeed*100);
            if (v > maxSpeed) {
                v *= 0.9f; //decay if over max speed
                if (v < maxSpeed)
                {
                    v = maxSpeed; // snap to max if under after decay
                }
            }
        }
        else    //we are about to reach the target, let's start decelerating.
        {
            if (v < 0)
            {
                //Probably negative acceleration?
                v += acceleration * 0.8f;
            }
            else
            {
                v = Mathf.Max(v - acceleration * 0.8f * Time.deltaTime, 0);
            }
        }

        Vector2 curVelocity = new Vector2();
        curVelocity[0] = v*cosangle;
        curVelocity[1] = v*sinangle;

        animator.SetFloat("VerticalMotion", curVelocity[1]);
        animator.SetFloat("HorizontalMotion", curVelocity[0]);

        rb.velocity = curVelocity;

    }

    void takeDamage()
    {
        health -= 1;
        AudioSource.PlayClipAtPoint(audio[Random.Range(0, audio.Length)], this.gameObject.transform.position);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bumpPlayer();
            collision.gameObject.GetComponent<playerShooter>().playHurtSound();
            Transform healthManager;
            healthManager = collision.gameObject.transform.Find("All UI/ScoreManger");
            healthManager.GetComponent<healthManager>().TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            takeDamage();
            GameObject sock = (GameObject)Instantiate(Resources.Load("Prefabs/smellySock"));
            sock.transform.position = transform.position;
            Destroy(collision.gameObject);
        }

    }


    void wander()
    {
        if (goalPoint != new Vector2(0, 0))
        {
            moveDirection = goalPoint - (Vector2)this.transform.position;
            if (moveDirection.magnitude < 0.1)
            {
                goalPoint = new Vector2(0, 0);
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
