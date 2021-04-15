using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent human;
    
    // Start is called before the first frame update
    void Start()
    {
        human = GetComponent<NavMeshAgent>();
        human.updateRotation = false;
        human.updateUpAxis = false;    
    }

    // Update is called once per frame
    void Update()
    {
        human.SetDestination(target.position);
    }
}
