using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerMovement playerMovement;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        Time.timeScale = 1;
        playerMovement.ToggleControls(true);

        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if(pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
            playerMovement.ToggleControls(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseMenu);

            pauseMenu.transform.GetChild(0).GetComponent<Button>().Select();
        }
    }

    public void SelectParty()
    {

    }
    public void SelectItems()
    {

    }
    public void SelectPlayer()
    {

    }
    public void SelectSave()
    {

    }
    public void SelectOptions()
    {

    }
    public void SelectExit()
    {

    }
}
