using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent nav;

    public Transform goal;
    public float speed;
    public Transform[] wayPoints;

    private int wayPointIndex;
    private float dist;

    public bool isPatrol = true;

    public bool playerInSightRange;
    public float sightRange;
    public LayerMask whatIsPlayer;


    void Start()
    {
        wayPointIndex = 0;
        transform.LookAt(wayPoints[wayPointIndex].position);
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
        {
            isPatrol = false;
            chasePlayer();
        }
        else
        {
            isPatrol = true;
        }

        if (isPatrol == true)
        {
            dist = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
            if (dist < 1f)
            {
                IncreaseIndex();
            }
            Patrol();
        }

    }

    void stopAI()
    {
        nav.isStopped = true;
    }

    void chasePlayer()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    void Patrol()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = wayPoints[wayPointIndex].position;


        //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        wayPointIndex++;

        if (wayPointIndex >= wayPoints.Length)
        {
            wayPointIndex = 0;
        }
        transform.LookAt(wayPoints[wayPointIndex].position);
    }
}