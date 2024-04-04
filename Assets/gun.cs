using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    public float damage = 10f;

    private float range = 150;

    public ParticleSystem muzzleflash;

    public bool weaponOn = false;
    void Update()
    {
        if(weaponOn == true)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }

            if (Input.GetButtonDown("Fire1") && weaponOn)
            {
                FindObjectOfType<AudioManager>().Play("Laser Gun 2");
            }

            if (Input.GetButtonUp("Fire1"))
            {
                FindObjectOfType<AudioManager>().Stop("Laser Gun 2");
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("Laser Gun 2");
        }
    }


    void Shoot()
    {
        muzzleflash.Play();
        RaycastHit hit;
 
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            AiTakesDmg target = hit.transform.GetComponent<AiTakesDmg>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    public void WeaponOnHand()
    {
        weaponOn = true;
    }

    public void offHand()
    {
        weaponOn = false;
    }
}
