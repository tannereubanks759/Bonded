using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Pistol : MonoBehaviour
{
    // Start is called before the first frame update
    public int magazine;

    public float damage;
    public float range;

    public LayerMask mask;

    public KeyCode shootKey;
    public KeyCode aimKey;
    public KeyCode reloadKey;


    Ray RayOrigin;
    RaycastHit hit;
    public GameObject bulletPlane;

    public int totalAmmo;

    public TextMeshProUGUI AmmoText;
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey) && magazine != 0){
            shoot();
        }
        if(Input.GetKeyDown(reloadKey) && magazine != 5)
        {
            reload();
        }

    }
    void shoot()
    {

        RayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(RayOrigin, out hit, range, mask)){
            if(hit.collider.gameObject.tag == "parasite")
            {
                Debug.Log("Hit Parasite");
                hit.collider.gameObject.GetComponent<Parasite>().damaged();
            }
            else
            {
                Instantiate(bulletPlane, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.up, hit.normal));
            }
        }
         magazine -= 1;
         UpdateUI();
    }
    void reload()
    {
        
        int reloadAmount = 5 - magazine;
        if (totalAmmo >= reloadAmount)
        {
            totalAmmo -= reloadAmount;
            magazine += reloadAmount;
            UpdateUI();
        }
        else
        {
            magazine += totalAmmo;
            totalAmmo = 0;
            UpdateUI();
        }
        
        
    }

    void UpdateUI()
    {
        AmmoText.text = magazine + " / " + totalAmmo;
    }
}
