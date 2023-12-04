using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalPanel : MonoBehaviour
{
    public GameObject Circuit;
    public GameObject DestroyedCircuit;
    public GameObject Sparks;
    public PickupObj pickup;
    public Animator anim;
    public Animator UI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PICKUP" && other.name == "Electrical Circuitry")
        {
            anim.SetBool("lights", false);
            Destroy(DestroyedCircuit);
            Circuit.SetActive(true);
            Sparks.SetActive(false);
            pickup.DropAndDelete();
            UI.SetBool("GameEnd", true);
           
        }
    }
}
