using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject Home;
    public GameObject ControlsMenu;
    public GameObject TutorialMenu;
    public AudioClip select;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            Home.SetActive(true);
            ControlsMenu.SetActive(false);
            TutorialMenu.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(string name)
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlaySelectSound();
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        PlaySelectSound();
        Application.Quit();
    }
    public void Return()
    {
        PlaySelectSound();
        Home.SetActive(true);
        TutorialMenu.SetActive(false);
        ControlsMenu.SetActive(false);
    }
    public void Controls()
    {

        TutorialMenu.SetActive(false);
        PlaySelectSound();
        Home.SetActive(false);
        ControlsMenu.SetActive(true);
    }
    public void Tutorial()
    {
        TutorialMenu.SetActive(true);
        PlaySelectSound();
        Home.SetActive(false);
        ControlsMenu.SetActive(false);
    }
    public void PlaySelectSound()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(select, 1f);
    }
}
