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
    // Start is called before the first frame update
    void Start()
    {
        breakerFixed = false;
        player = Screens.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isPlaying == true && Time.time > nextTime && donePlaying == false)
        {
            parasite.TeleportToSleep();
            parasite.SetStateToEating();
            donePlaying = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && donePlaying == false && player.isPlaying != true && breakerFixed)
        {
            Debug.Log("play video");
            player.Play();
            nextTime = Time.time + (float)player.length;
        }
    }
}
