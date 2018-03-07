using System;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private int waypointIndex = 0;
    private Transform target;

    public float speed = 10f;

    public void Start()
    {
        target = Waypoints.instances[0];
    }

    public void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if(waypointIndex == Waypoints.instances.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.instances[waypointIndex];
    }
}
