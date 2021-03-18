using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    // Start is called before the first frame update
    public int targetHealth = 3;
    public int moveDistance = 500;
    public int dummySpeed;

    public MeshRenderer bodyMesh;
    public Material[] enemyColors;

    public void Start()
    {

        SetUpEnemy();
        StartCoroutine(Move());
        
    }

    public void TakeDamage(int damage)
    {
        targetHealth -= damage;

        if (targetHealth <= 0)
            Destroy(this.gameObject);
    }
    public void SetUpEnemy()
    {
        EnemySizes eSize = (EnemySizes)Random.Range(0, 3);

        switch (eSize)
        {
            case EnemySizes.Small:
                this.transform.localScale = Vector3.one * 0.2f;
                this.GetComponent<MeshRenderer>().material = enemyColors[0];
                bodyMesh.material = enemyColors[0];
                dummySpeed = 10;
                break;
            case EnemySizes.Medium:
                this.transform.localScale = Vector3.one * 0.6f;
                this.GetComponent<MeshRenderer>().material = enemyColors[1];
                bodyMesh.material = enemyColors[1];
                dummySpeed = 5;
                break;
            case EnemySizes.Large:
                this.transform.localScale = Vector3.one * 1.5f;
                this.GetComponent<MeshRenderer>().material = enemyColors[2];
                bodyMesh.material = enemyColors[2];
                dummySpeed = 1;
                break;
        }
    }
    IEnumerator Move()
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate((Vector3.right * Time.deltaTime) * dummySpeed);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        for (int i = 0; i < moveDistance; i++)
        {
            transform.Translate((Vector3.left * Time.deltaTime) * dummySpeed);
            yield return null;
        }
    }
}
