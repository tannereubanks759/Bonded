using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBreaker : MonoBehaviour
{
    public GameObject breaker;
    public GameObject lever;
    public GameObject window;
    public PickupObj pickup;
    public Parasite enemy;
    // Start is called before the first frame update
    void Start()
    {
        lever.SetActive(false);
        window.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(lever.activeSelf == true && window.activeSelf == true)
        {
            Instantiate(breaker, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (enemy.state == Parasite.enemyStates.Sleeping)
        {
            if (other.name == lever.name)
            {
                lever.SetActive(true);
                pickup.DropAndDelete();
            }
            if (other.name == window.name)
            {
                window.SetActive(true);
                pickup.DropAndDelete();
            }
        }
        
    }
}

