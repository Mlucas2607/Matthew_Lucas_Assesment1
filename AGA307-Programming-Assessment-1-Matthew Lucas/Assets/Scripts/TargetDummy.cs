﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    // Start is called before the first frame update
    public int targetHealth = 3;

    public void TakeDamage(int damage)
    {
        targetHealth -= damage;

        if (targetHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log(this.gameObject.name + " has been destroyed");
        }
        else
            Debug.Log(this.gameObject.name + " Recieved " + damage + " Damage!");
    }
}
