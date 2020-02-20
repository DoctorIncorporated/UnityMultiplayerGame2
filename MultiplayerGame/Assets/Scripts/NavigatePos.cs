using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigatePos : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("dist", agent.remainingDistance);
    }

    public void NavigateTo(Vector3 pos)
    {
        agent.SetDestination(pos);
    }
}
