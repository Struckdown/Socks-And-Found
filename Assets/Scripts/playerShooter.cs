using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooter : MonoBehaviour
{
    public GameObject sock;
    public int flyingSocksLeft = 10;
    private Vector2 shootDir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootDir = Input.mousePosition - transform.position;
            GameObject sock = (GameObject)Instantiate(Resources.Load("Prefabs/FlyingSock"));
            sock.transform.position = transform.position;
            //sock.moveDirection = new Vector2(1, 5);

        }
    }
}
