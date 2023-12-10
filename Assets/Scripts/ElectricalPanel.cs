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
    public Material fixedMat;
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
            GameObject.Find("Alarm").GetComponent<AudioSource>().Stop();
            this.GetComponent<MeshRenderer>().material = fixedMat;
            anim.SetBool("lights", false);
            Destroy(DestroyedCircuit);
            Circuit.SetActive(true);
            Sparks.SetActive(false);
            pickup.DropAndDelete();
            UI.SetBool("GameEnd", true);
           
        }
    }
}
