using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public GameObject GameOverUI;

public int maxHealth = 3;
    private int currentHealth;

    public Image[] hearts;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHearts();
        }

        if (currentHealth <= 0)
        {
            Debug.Log("player is dead");
            Dead();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHealth;
        }
    }
    void Dead()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
