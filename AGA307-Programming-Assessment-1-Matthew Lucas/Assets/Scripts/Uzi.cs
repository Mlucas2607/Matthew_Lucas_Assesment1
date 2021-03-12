using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : MonoBehaviour
{
    public GameObject[] weaponEffects;
    public Transform shootPos;
    [Header("Weapon Stats")]
    public float fireRate = 5f;
    public int gunDamage = 1;
    public float bulletSpread = 0.1f;

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(weaponEffects[0], shootPos.position, shootPos.rotation);

        Ray gunRay = new Ray(shootPos.position, shootPos.forward);
        RaycastHit hit;

        gunRay.direction = shootPos.forward + new Vector3(Random.Range(-bulletSpread, bulletSpread), Random.Range(-bulletSpread, bulletSpread), Random.Range(-bulletSpread, bulletSpread));

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
