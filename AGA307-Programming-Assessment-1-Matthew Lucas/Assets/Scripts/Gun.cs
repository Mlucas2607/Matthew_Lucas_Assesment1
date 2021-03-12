using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] weaponEffects;
    public float fireRate = 2f;
    public Transform shootPos;
    public int gunDamage = 1;

    private float nextTimeToFire = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        if (Physics.Raycast(gunRay, out hit, 100) && hit.collider.tag == "Target")
        {
            hit.collider.SendMessage("TakeDamage", gunDamage);
            Instantiate(weaponEffects[1], hit.point, Quaternion.identity);
        }
        else
            Instantiate(weaponEffects[2], hit.point, Quaternion.identity);

    }
}
