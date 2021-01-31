using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooter : MonoBehaviour
{
    public int flyingSocksLeft = 10;
    private Vector2 shootDir;
    public int health = 100;
    public AudioClip[] audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 200));
            Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);

            shootDir = worldPoint2d;

            GameObject sock = (GameObject)Instantiate(Resources.Load("Prefabs/FlyingSock"));
            sock.transform.position = transform.position;
            sock.GetComponent<FlyingSock>().moveDirection = shootDir;

        }
    }

    public void playHurtSound()
    {
        AudioSource.PlayClipAtPoint(audio[Random.Range(0, audio.Length)], this.gameObject.transform.position);
    }
}
