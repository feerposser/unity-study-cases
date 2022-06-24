using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceCar : MonoBehaviour
{

    public NavMeshAgent navigation;
    public List<Transform> waypoints;
    public int currentWaypointIndex = 1;

    void Start()
    {
        navigation = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waypoints.Count > 0)
        {
            float distance = Vector3.Distance(waypoints[currentWaypointIndex].position, transform.position);
            navigation.SetDestination(waypoints[currentWaypointIndex].position);

            if(distance <= navigation.stoppingDistance)
            {
                if (currentWaypointIndex == 0)
                    currentWaypointIndex = 1;
                else
                    currentWaypointIndex = 0;
            }
        }
        
    }
}
