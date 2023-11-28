
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMovement: MonoBehaviour
{
    public NavMeshAgent badGuy;
    public float squareOfMovement = 45f;
    private float xMin;
    private float xMax;
    private float zMin;
    private float zMax;

    private float xPosition;
    private float zPosition;
    private float yPosition;

    public float closeEnough = 2f;



    // Start is called before the first frame update
    void Start()
    {
        xMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMin = -squareOfMovement;
        zMax = squareOfMovement;

        newLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();
        }
    }

    public void newLocation()
    {
        xPosition = Random.Range(xMin, xMax);
        zPosition = Random.Range(zMin, zMax);
        yPosition = transform.position.y;

        badGuy.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}
