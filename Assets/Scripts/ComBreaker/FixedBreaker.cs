using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBreaker : MonoBehaviour
{
    public Animator anim;
    public Material fixedMat;
    // Start is called before the first frame update
    void Start()
    {
        fixedMat.EnableKeyword("_EMISSION");
        fixedMat.SetColor("_EmissionColor", Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnLightsGreen()
    {
        fixedMat.EnableKeyword("_EMISSION");
        fixedMat.SetColor("_EmissionColor", Color.green);
    }
}
