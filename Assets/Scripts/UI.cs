using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public CharacterControllerScript player;
    private void Start()
    {
        player = GameObject.FindObjectOfType<CharacterControllerScript>();

    }
    public void setTImeScale()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.pistolObj.SetActive(false);
        player.walkSource.Stop();
        player.isPaused = true;
        FlashlightLook.isPaused = true;
        Time.timeScale = 0f;
    }
    
}
