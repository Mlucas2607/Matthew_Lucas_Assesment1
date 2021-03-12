using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject[] weaponEffects;
    public Transform shootPos;
    [Header("Weapon Stats")]
    public int gunDamage = 2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
    }


    void Shoot()
    {
        Instantiate(weaponEffects[0], shootPos.position, shootPos.rotation);

        Ray gunRay = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit;

        if (Physics.Raycast(gunRay, out hit, 100))
        {
            if (hit.collider.tag == "Target")
            {
                hit.collider.SendMessage("TakeDamage", gunDamage);
                Instantiate(weaponEffects[1], hit.point, Quaternion.identity);
            }
            else
                Instantiate(weaponEffects[2], hit.point, Quaternion.identity);
        }
    }
}

