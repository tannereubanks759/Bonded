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

    public AudioSource sound;
    public AudioClip ShootSound;
    public AudioClip Reload;
    public AudioClip OutOfAmmoClip;


    public float fireRate;
    float nextFire;
    void Start()
    {
        sound.clip = ShootSound;
        UpdateUI();
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey) && magazine != 0 && Time.time > nextFire){
            shoot();
            nextFire = Time.time + fireRate;
        }
        else if (Input.GetKeyDown(shootKey) && magazine <= 0)
        {
            sound.clip = OutOfAmmoClip;
            sound.Play();
        }
        if(Input.GetKeyDown(reloadKey) && magazine != 5)
        {
            reload();
        }

    }
    void shoot()
    {
        sound.Play();
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
        if(totalAmmo != 0)
        {
            sound.PlayOneShot(Reload, 1);
            sound.clip = ShootSound;
        }
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
