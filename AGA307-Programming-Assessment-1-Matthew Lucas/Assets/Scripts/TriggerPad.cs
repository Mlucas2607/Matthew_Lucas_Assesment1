using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change
    public Material matGreen;
    public Material matYellow;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //changes sphers color to green
            sphere.GetComponent<MeshRenderer>().material = matGreen;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increas the spheres scale by 0.01 on all axis
            sphere.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //Change the spheres colour to yellow
            sphere.GetComponent<MeshRenderer>().material = matYellow;
            //set the spheres size back to 1
            sphere.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
    }
}

