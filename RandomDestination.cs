using UnityEngine;
using UnityEngine.AI;

public static class NavMeshExtensions
{
    public static Vector3 RandomPosition(this NavMeshAgent agent, float radius)
    {
        var randDirection = Random.insideUnitSphere * radius;
        randDirection += agent.transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, radius, -1);
        return navHit.position;
    }
}

public class RandomDestination : MonoBehaviour
{
    NavMeshAgent agent;
    public float radius = 100;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetRandomDestination", 0, 5);
    }

    void SetRandomDestination()
    {
        if (!agent.hasPath)
        {
            agent.SetDestination(agent.RandomPosition(radius));
        }
    }
}
