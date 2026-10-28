using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent nma;

    // How close the player can get before the enemy takes notice
    [SerializeField] float chaseRange = 5.0f;
    
    float distanceToTarget = Mathf.Infinity;

    private bool isProvoked = false;

    void Start()
    {
        nma = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Measures the distance between the enemy and the player
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        // Checks the range against the distance
        if(isProvoked)
        {
            EngageTarget(); 
        }
        else if(distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }

        //if(distanceToTarget <= chaseRange)
        //{
            //nma.SetDestination(target.position);
        //}
        //nma.SetDestination(target.position);
        
    }

    void OnDrawGizmosSelected()
    {
        // Display the chase radius when selected
        Gizmos.color = Color.red; // Choose a color
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void EngageTarget()
    {
        if(distanceToTarget >= nma.stoppingDistance)
        {
            ChaseTarget(); 
        }

        if(distanceToTarget <= nma.stoppingDistance)
        {
            AttackTarget(); 
        }
    }

    private void ChaseTarget()
    {
        nma.SetDestination(target.position); 
    }
    
    private void AttackTarget()
    {
        // Temp for now, to show that the enemy is attacking
        print(name + " is attacking " + target.name);
    }
}
