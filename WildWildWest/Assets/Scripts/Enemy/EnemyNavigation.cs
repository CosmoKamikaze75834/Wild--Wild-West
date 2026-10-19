using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavigation : MonoBehaviour
{
    private NavMeshAgent _agent;

    public bool PathPending => _agent.pathPending;//рассчитывает ли Unity путь до заданной точки
    public float RemainingDistance => _agent.remainingDistance;//показывает оставшееся расстояние до конечной точки текущего пути.
    public float StoppingDistance => _agent.stoppingDistance;//задаёт расстояние от конечной точки, на котором агент может остановиться.

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    //задать точку назначения
    public void SetDestination(Vector3 destination) =>
        _agent.SetDestination(destination);

    //остановить движение
    public void Stop() =>
        _agent.isStopped = true;

    //возобновить движение
    public void Resume() =>
        _agent.isStopped = false;

    //переместить врага в точку спавна
    public bool Warp(Vector3 position) =>
        _agent.Warp(position);

    public void ResetPath()
    {
        _agent.ResetPath();
    }
}