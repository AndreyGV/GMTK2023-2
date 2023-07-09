using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMoveSpeed : MonoBehaviour
{
    public GameObject[] newWaypoints = new GameObject[2];
    public Transform[] waypoints = new Transform[2];
    public float moveSpeed = 5f;
    public float returnSpeed = 2f;

    private int currentWaypoint = 0;
    private bool movingForward = true;

    void Update()
    {
        newWaypoints[0] = GameObject.Find("first");
        newWaypoints[1] = GameObject.Find("SpawnManager");
        if (currentWaypoint < waypoints.Length)
        {
            // Move towards the current waypoint at the current move speed
            transform.position = Vector3.MoveTowards(transform.position, newWaypoints[currentWaypoint].transform.position, Time.deltaTime * moveSpeed);

            if (transform.position == newWaypoints[currentWaypoint].transform.position)
            {
                if (movingForward)
                {
                    currentWaypoint++;
                }
                else
                {
                    currentWaypoint--;
                }

                // Reverse direction when we reach the end or the start of the waypoint array
                if (currentWaypoint == newWaypoints.Length)
                {
                    movingForward = false;
                    currentWaypoint--;
                }
                else if (currentWaypoint < 0)
                {
                    movingForward = true;
                    currentWaypoint = 0;
                }
            }
        }
        else
        {
            // If we've reached the end of the waypoints, return to the start at the return speed
            transform.position = Vector3.MoveTowards(transform.position, newWaypoints[0].transform.position, Time.deltaTime * returnSpeed);
        }
    }
}
