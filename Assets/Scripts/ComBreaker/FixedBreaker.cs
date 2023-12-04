using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBreaker : MonoBehaviour
{
    public Animator anim;
    public Material fixedMat;
    public Material ComLightMat;
    public ComOffice office;

    public Animator Coms;
    // Start is called before the first frame update
    void Start()
    {
        fixedMat.EnableKeyword("_EMISSION");
        fixedMat.SetColor("_EmissionColor", Color.red);
        ComLightMat.EnableKeyword("_EMISSION");
        ComLightMat.SetColor("_EmissionColor", Color.red);
        office = GameObject.FindObjectOfType<ComOffice>();
        Coms = GameObject.Find("Communications Area").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnLightsGreen()
    {
        Coms.SetBool("breakerFixed", true);
        fixedMat.EnableKeyword("_EMISSION");
        fixedMat.SetColor("_EmissionColor", Color.green);
        ComLightMat.EnableKeyword("_EMISSION");
        ComLightMat.SetColor("_EmissionColor", Color.green);
        office.breakerSwitched = true;
    }
}
