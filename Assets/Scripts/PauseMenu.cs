using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public KeyCode pauseKey = KeyCode.Escape;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        CursorDisable();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (pauseMenu.activeSelf)
            {
                resume();
            }
            else
            {
                pauseMenu.SetActive(true);
                CursorEnable();
            }
        }
    }

    public void resume()
    {

        CursorDisable();
        pauseMenu.SetActive(false);
    }

    public void CursorDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CursorEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
