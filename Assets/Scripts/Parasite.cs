using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Parasite : MonoBehaviour
{
    public float health = 100;
    public int hitTimes = 0;

    //this will be the variables to control the state in which the parasite is in at any given moment
    public enum enemyStates {Chasing, Roaming, Eating, Sleeping};
    public enemyStates state;
    private enemyStates cashedState;

    private NavMeshAgent agent;

    public GameObject eatObject;
    public GameObject sleepObject;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }



    void Update()
    {
        switch (state)
        {
            case enemyStates.Chasing:
                Chasing();
                break;
            case enemyStates.Roaming:
                Roaming();
                break;
            case enemyStates.Eating:
                Eating();
                break;
            case enemyStates.Sleeping:
                Sleeping();
                break;
        }
    }

    void Chasing()
    {

    }
    void Roaming()
    {

    }
    void Eating()
    {
        if(agent == null)
        {
            return;
        }
        agent.SetDestination(eatObject.transform.position);

        if(hitTimes == 5)
        {
            state = enemyStates.Sleeping;
        }
    }
    void Sleeping()
    {
        agent.speed = 10;
        agent.SetDestination(sleepObject.transform.position);
    }


    public void damaged()
    {
        hitTimes += 1;
    }
}
