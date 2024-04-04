using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTakesDmg : MonoBehaviour
{

    public float health = 50f;

    public ObjectiveCheck objectivecheck;
    public void TakeDmg(float amount)
    {
        health -= amount;

        if(health <= 0f)
        {
            Die();
        }
    }



    void Die()
    {
        Destroy(gameObject);
        objectivecheck.loseAi();
    }
}
