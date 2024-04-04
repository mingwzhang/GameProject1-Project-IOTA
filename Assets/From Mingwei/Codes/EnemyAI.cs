using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Handles enemy AI behavior such as patrolling and chasing the player.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent nav;
    private Transform currentTarget;
    private int wayPointIndex;

    [Header("Settings")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] private float sightRange;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private float patrolDistanceThreshold = 0.5f;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateBehavior();
    }

    // Initializes the enemy AI by setting up waypoints and NavMeshAgent.
    private void Initialize()
    {
        if (wayPoints.Length == 0 || playerTransform == null)
        {
            Debug.LogError("Waypoints or player transform not set in EnemyAI.");
            enabled = false;
            return;
        }

        wayPointIndex = 0;
        currentTarget = wayPoints[wayPointIndex];
        nav = GetComponent<NavMeshAgent>();
    }

    // Updates the enemy behavior based on player proximity.
    private void UpdateBehavior()
    {
        bool playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange)
        {
            ChasePlayer(playerTransform.position);
        }
        else
        {
            Patrol();
        }
    }

    // Sets the destination to chase the player.
    private void ChasePlayer(Vector3 playerPosition)
    {
        nav.SetDestination(playerPosition);
    }

    // Handles patrolling behavior by moving between waypoints.
    private void Patrol()
    {
        if (nav.remainingDistance < patrolDistanceThreshold)
        {
            SetNextWaypoint();
        }
    }

    // Sets the next waypoint for patrolling.
    private void SetNextWaypoint()
    {
        wayPointIndex = (wayPointIndex + 1) % wayPoints.Length;
        currentTarget = wayPoints[wayPointIndex];
        nav.SetDestination(currentTarget.position);
    }
}
