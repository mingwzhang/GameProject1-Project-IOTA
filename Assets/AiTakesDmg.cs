using UnityEngine;

/// <summary>
/// Handles damage taking and destruction logic for an AI character.
/// </summary>
public class AiTakesDmg : MonoBehaviour
{
    private float health = 50f;
    private ObjectiveCheck objectiveCheck;

    // Inflicts damage to the AI character.
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    // Destroys the AI character and notifies the ObjectiveCheck component.
    private void Die()
    {
        Destroy(gameObject);
        NotifyObjectiveCheck();
    }

    // Notifies the ObjectiveCheck component about the AI character's destruction.
    private void NotifyObjectiveCheck()
    {
        if (objectiveCheck != null)
        {
            objectiveCheck.loseAi();
        }
        else
        {
            Debug.LogWarning("ObjectiveCheck reference not set in AiTakesDmg.");
        }
    }
}
