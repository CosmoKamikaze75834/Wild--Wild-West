using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent _agent;

    public bool PathPending => _agent.pathPending;
    public float RemainingDistance => _agent.remainingDistance;
    public float StoppingDistance => _agent.stoppingDistance;

    private void Awake() =>
        _agent = GetComponent<NavMeshAgent>();

    public void SetDestination(Vector3 destination) =>
        _agent.SetDestination(destination);

    public void Stop() =>
        _agent.isStopped = true;

    public void Resume() =>
        _agent.isStopped = false;

    public bool Warp(Vector3 position) =>
        _agent.Warp(position);

    public void ResetPath() =>
        _agent.ResetPath();
}