using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupObj : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    CharacterControllerScript controller;
    public KeyCode pickupKey;

    bool looking = false;
    Collider hitObj;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pickupKey) && looking == true)
        {
            if (hitObj.name == "Flashlight")
            {
                controller.hasFlashlight = true;
                controller.flashlightObj.SetActive(true);
                Destroy(hitObj.gameObject);
            }
            else if (hitObj.name == "pistolStatic")
            {
                controller.hasGun = true;
                controller.pistolObj.SetActive(true);
                Destroy(hitObj.gameObject);
            }
            crosshair.GetComponent<Image>().color = Color.red;
            hitObj = null;
            looking = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PICKUP")
        {
            hitObj = other;
            crosshair.GetComponent<Image>().color = Color.green;
            looking = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        crosshair.GetComponent<Image>().color = Color.red;
        hitObj = null;
        looking = false;
    }
}
