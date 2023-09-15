using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlaneScript : MonoBehaviour
{
    private float nextFire;
    private void Start()
    {
        nextFire = Time.time + 5;
    }
    private void Update()
    {
        if (Time.time > nextFire)
        {
            Destroy(this.gameObject);
        }
    }
}
