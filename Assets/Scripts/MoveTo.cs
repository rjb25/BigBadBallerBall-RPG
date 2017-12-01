using UnityEngine;
using UnityEngine.AI;
//Unused class for NavMesh testing
public class MoveTo : MonoBehaviour
{
    public Transform goal;
    public string goalName;
    NavMeshAgent agent;

    void Start()
    {
        goal = GameObject.Find(goalName).transform;
        NavMeshPath path = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, goal.position, NavMesh.AllAreas, path);
        foreach (Vector3 corner in path.corners)
        {
            print(corner);
        }
    }
}