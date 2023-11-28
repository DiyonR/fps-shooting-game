using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private Transform PLayer;
    public float attackRange = 10f;

    public Material defaultColor;
    public Material attackMaterial;
    private Renderer rend;

    private bool foundPlayer;

    private void Awake()
    {
        PLayer = GameObject.FindGameObjectWithTag("Player").transform;
        enemyMovement = GetComponent<EnemyMovement>();
        rend = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, PLayer.position) <= attackRange)
        {
            rend.sharedMaterial = attackMaterial;
            enemyMovement.badGuy.SetDestination(PLayer.position);
            foundPlayer = true;
        }
        else if (foundPlayer)
        {
            rend.sharedMaterial = defaultColor;
            enemyMovement.newLocation();
            foundPlayer = false;
        }
    }
}
