using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooter : MonoBehaviour
{
    public int flyingSocksLeft = 10;
    private Vector2 shootDir;
    public int health = 100;
    public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            shootDir = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition) - transform.position;
            
            GameObject sock = (GameObject)Instantiate(Resources.Load("Prefabs/FlyingSock"));
            sock.transform.position = transform.position;
            sock.GetComponent<FlyingSock>().moveDirection = shootDir;
            //            collision.gameObject.GetComponent<playerShooter>().takeDamage(damage);
            //sock.moveDirection = new Vector2(1, 5);

        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
