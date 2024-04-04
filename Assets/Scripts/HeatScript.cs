using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatScript : MonoBehaviour
{
    public bool enter;

    public HealthSystem Healthsystem;
    public float damageToTake;
    
    // Start is called before the first frame update
    void Start()
    {
        Healthsystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Healthsystem.TakeDamage(damageToTake);
        }
    }
}
