using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform destination;

    AILerp ai;
    
    void Awake() 
    {
        ai = GetComponent<AILerp>(); 
    }

    void Update() 
    {
        ai.destination = destination.position;
    }
}
