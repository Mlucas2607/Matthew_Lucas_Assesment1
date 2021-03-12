using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastSphere : MonoBehaviour
{
    public Transform cameraPos;
    public Material matRed;
    public Material matBlue;
    private GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            Ray gunRay = new Ray(cameraPos.position, cameraPos.forward);
            RaycastHit hit;

            if (Physics.Raycast(gunRay, out hit, 10) && hit.collider.tag == "Sphere")
            {
                sphere = hit.collider.gameObject;
                Debug.DrawLine(gunRay.origin, hit.point, Color.green, 0.125f);
                hit.collider.GetComponent<MeshRenderer>().material = matRed;

                if (Input.GetKey(KeyCode.E))
                    sphere.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);

            }
            else
            {
                Debug.DrawRay(gunRay.origin, gunRay.direction * 10, Color.red, 0.125f);
                sphere.GetComponent<MeshRenderer>().material = matBlue;
                
            }
        }
    }
}
