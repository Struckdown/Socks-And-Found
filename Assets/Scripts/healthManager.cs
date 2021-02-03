using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 20;
    public HealthBarScript healthBar;
    public GameObject gameOverMenu;
    public bool invulnerable = false;

    void Start()
    {
        currentHealth = GameManager.playerHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.L)) {
        //     TakeDamage(1);
        // }
    }

    public void TakeDamage(int damage = 1) {
        if (invulnerable)
        {
            return;
        }
        currentHealth -= damage;
        if (currentHealth == 0) {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        healthBar.SetHealth(currentHealth);
        GameManager.playerHealth = currentHealth;
    }
}
