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

    public List<GameObject> EatPositions;
    public List<GameObject> SleepPositions;
    public GameObject parasiteHome;
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
        agent.speed = 3.5f;
        if(agent == null)
        {
            return;
        }
        agent.SetDestination(eatObject.transform.position);

        if(hitTimes == 5)
        {
            eatObject = (GameObject)EatPositions[EatPositions.IndexOf(eatObject) + 1];
            state = enemyStates.Sleeping;
        }
        
    }
    void Sleeping()
    {
        hitTimes = 0;
        if(agent.speed != 0)
        {
            agent.SetDestination(sleepObject.transform.position);
            agent.speed = 10;
        }
        if (inRange(sleepObject))
        {
            agent.speed = 0;
            agent.Warp(parasiteHome.transform.position);
            sleepObject = (GameObject)SleepPositions[SleepPositions.IndexOf(sleepObject) + 1];
        }
    }

    public void damaged()
    {
        hitTimes += 1;
    }

    public bool inRange(GameObject obj)
    {
        bool inRange = Vector3.Distance(transform.position, obj.transform.position) <= 1;
        return inRange;
    }

    public void SetStateToEating()
    {
        this.state = enemyStates.Eating;
    }
    public void TeleportToSleep()
    {
        agent.Warp(sleepObject.transform.position);
    }
}
