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

    public Animator anim;

    private float sleepingTime = 0;

    private bool hasSleepTime;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = enemyStates.Eating;

        hasSleepTime = false;
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
        
        if (!inRange(eatObject) && agent.speed == 0)
        {
            agent.speed = 3.5f;
        }
        if (anim.GetBool("breakLight") == false)
        {
            if (agent.speed != 0)
            {
                agent.speed = 3.5f;
                agent.SetDestination(eatObject.transform.position);
            }
            if (inRange(eatObject, .2f) && eatObject == EatPositions[1])
            {
                if(hasSleepTime == false)
                {
                    sleepingTime = Time.time + 2f;
                    hasSleepTime = true;
                }
                //agent.speed = 0;
                Vector3 targetDirection = GameObject.Find("LightCol").transform.position - this.transform.position;
                float SingleStep = Time.deltaTime * 5;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, SingleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);

                if (Time.time > sleepingTime)
                {
                    anim.SetBool("breakLight", true);
                }
            }
        }
        
        if(hitTimes == 5)
        {
            if(eatObject == EatPositions[EatPositions.Count - 1])
            {
                state = enemyStates.Sleeping;
            }
            else
            {
                eatObject = (GameObject)EatPositions[EatPositions.IndexOf(eatObject) + 1];
                state = enemyStates.Sleeping;
            }
            
        }
        
    }
    void Sleeping()
    {
        
        anim.SetBool("breakLight", false);
        anim.SetBool("BreakLEnter", false);
        if (anim.GetBool("GoIn") == false)
        {
            hitTimes = 0;
            if (agent.speed != 0)
            {
                agent.SetDestination(sleepObject.transform.position);
                agent.speed = 10;
                sleepingTime = Time.time + .8f;
            }
            if (inRange(sleepObject))
            {
                agent.speed = 0;
                Vector3 targetDirection = sleepObject.GetComponentInChildren<BoxCollider>().gameObject.transform.position - this.transform.position;
                float SingleStep = Time.deltaTime * 5;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, SingleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
                
                if(Time.time > sleepingTime)
                {
                    anim.SetBool("GoIn", true);
                }

            }
        }
        
    }

    public void damaged()
    {
        hitTimes += 1;
    }

    public bool inRange(GameObject obj)
    {
        bool inRange = Vector3.Distance(transform.position, obj.transform.position) <= .1;
        return inRange;
    }
    public bool inRange(GameObject obj, float distance)
    {
        bool inRange = Vector3.Distance(transform.position, obj.transform.position) <= distance;
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

    public void DoneVenting()
    {
        anim.SetBool("GoIn", false);
        sleepObject = SleepPositions[SleepPositions.IndexOf(sleepObject) + 1];  //go to next vent the next time this parasite sleeps
        agent.Warp(parasiteHome.transform.position);
    }

    public void EnterBreakPanel()
    {
        anim.SetBool("BreakLEnter", true);
    }
}
