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

    public Animator breakerAnim;

    public GameObject pickupPos;

    public bool isHolding = false;
    public GameObject holdingObj;
    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<CharacterControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            holdingObj.transform.position = pickupPos.transform.position;
            holdingObj.transform.rotation = pickupPos.transform.rotation;
        }
        if(Input.GetKeyDown(pickupKey) && isHolding == true)
        {
            this.GetComponent<Collider>().enabled = true;
            holdingObj = null;
            isHolding = false;
        }

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
            else if (hitObj.tag == "PICKUP" && hitObj.name == "Breaker_Window")
            {
                isHolding = true;
                holdingObj = hitObj.gameObject;
                this.GetComponent<Collider>().enabled = false;
            }
            else if (hitObj.tag == "PICKUP" && hitObj.name == "Breaker_Lever")
            {
                isHolding = true;
                holdingObj = hitObj.gameObject;
                this.GetComponent<Collider>().enabled = false;
            }
            else if (hitObj.tag == "INTERACT" && hitObj.name == "Breaker_Window")
            {
                breakerAnim = GameObject.FindGameObjectWithTag("Breaker").GetComponent<Animator>();
                if (breakerAnim.GetBool("isOpened") == false)
                {
                    breakerAnim.SetBool("isOpened", true);
                }
                else
                {
                    breakerAnim.SetBool("isOpened", false);
                }
            }
            else if(hitObj.tag == "INTERACT" && hitObj.name == "Breaker_Lever")
            {
                if(breakerAnim.GetBool("isSwitched") == false)
                {
                    breakerAnim.SetBool("isSwitched", true);
                }
                else
                {
                    breakerAnim.SetBool("isSwitched", false);
                }
            }
            
            else if(hitObj.name == "Handle")
            {
                hitObj.GetComponentInParent<BoxCollider>().GetComponentInParent<Animator>().SetBool("isOpen", true);
            }
            crosshair.GetComponent<Image>().color = Color.red;
            hitObj = null;
            looking = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PICKUP" || other.tag == "INTERACT")
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

    public void DropAndDelete()
    {
        this.GetComponent<Collider>().enabled = true;
        Destroy(holdingObj);
        holdingObj = null;
        isHolding = false;
    }
}
