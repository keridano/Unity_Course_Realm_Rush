using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 5;
    [SerializeField] Text healthText;

    void Start()
    {
        SetHealthText();
    }

    void OnTriggerEnter(Collider other)
    {
        playerHealth--;
        SetHealthText();

        if (playerHealth <= 0)
            print("You lose!");
    }

    private void SetHealthText()
    {
        healthText.text = $"Player Health\n{playerHealth}";
    }

}
