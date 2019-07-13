using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {
    [Tooltip("怪物要寻找的人")]
    Transform player;
    private NavMeshAgent agent;
    
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.position);
       
	}
}
