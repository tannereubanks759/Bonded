using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class ComOffice : MonoBehaviour
{
    public GameObject Screens;
    VideoPlayer player;
    public bool donePlaying;
    float nextTime;

    public Parasite parasite;

    public bool breakerFixed;
    public GameObject sparks;
    public Animator hallPanel;
    public MeshRenderer hallPanelRender;

    public bool breakerSwitched;
    public GameObject circuit;
    public GameObject dCircuit;
    public Material circuitDestroyedMat;
    public Material circuitMat;
    public Material ComOfficeMat;
    public GameObject ColWall;
    
    // Start is called before the first frame update
    void Start()
    {
        ColWall.SetActive(false);
        hallPanelRender.material = circuitMat;
        ComOfficeMat.SetColor("_EmissionColor", Color.red);
        breakerSwitched = false;
        breakerFixed = false;
        player = Screens.GetComponent<VideoPlayer>();
        sparks.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isPlaying == true && Time.time > nextTime && donePlaying == false)
        {
            hallPanelRender.material = circuitDestroyedMat;
            ColWall.SetActive(false);
            circuit.SetActive(false);
            dCircuit.SetActive(true);
            parasite.TeleportToSleep();
            parasite.SetStateToEating();
            sparks.SetActive(true);
            hallPanel.SetBool("lights", true);
            hallPanel.gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("Alarm").GetComponent<AudioSource>().Play();
            donePlaying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && donePlaying == false && player.isPlaying != true && breakerFixed && breakerSwitched)
        {
            Debug.Log("play video");
            player.Play();
            nextTime = Time.time + (float)player.length;
            ColWall.SetActive(true);
        }
    }
}
