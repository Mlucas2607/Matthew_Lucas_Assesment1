using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public GameObject[] weapons;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        for (int i = 0; i < 9; i++)
        {
            string key = (i + 1).ToString();

            if (Input.GetKeyDown(key))
                WeaponsSelect(i);
        }
    }

    void WeaponsSelect(int weaponID)
    {
        for (int i = 0; i < weapons.Length; i++)
            weapons[i].SetActive(false);

        weapons[weaponID].SetActive(true);
    }
}
