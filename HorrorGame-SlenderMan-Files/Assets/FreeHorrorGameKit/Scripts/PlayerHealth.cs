using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;

    public string SceneToLoadOnDeath;

    private void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateUI();
        // Update UI Here

        if (health <= 0)
        {
            if (SceneToLoadOnDeath != null)
            {
                SceneManager.LoadScene(SceneToLoadOnDeath);
            }
            else
            {
                // Reload scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }

    public void UpdateUI()
    {
        // Update UI health slide or counter here
    }
}