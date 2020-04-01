using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] float baseHealth = 3;
    [SerializeField] int damage = 1;
    [SerializeField] GameObject gameOverText;
    float playerHealth = 5;
    Text healthText;

    private void Start()
    {
        playerHealth = baseHealth - PlayerPrefsController.GetMasterDifficulty();
        healthText = GetComponent<Text>();
        UpdateHealthDisplay();
    }

    public void DealPlayerDamage()
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            FindObjectOfType<LevelController>().GameOver();
        }
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        healthText.text = playerHealth.ToString();
    }

}
