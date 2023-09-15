using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parasite : MonoBehaviour
{
    public float health = 100;
    

    //this will be the variables to control the state in which the parasite is in at any given moment
    public enum enemyStates {Chasing, Roaming, Eating, Sleeping};
    public enemyStates state;
    private enemyStates cashedState;



    void Start()
    {
        state = enemyStates.Roaming;
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

    }
    void Sleeping()
    {

    }
}
