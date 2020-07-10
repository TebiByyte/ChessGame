using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Camera camera;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject cameraController;
    public GameObject exitButton;

    public void onPlayClick()
    {
        mainMenu.SetActive(false);
        camera.GetComponent<MainGame>().beginGame();
        cameraController.GetComponent<CameraController>().canMove = true;
        exitButton.SetActive(true);
    }

    public void onSettingsClick()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void onExitClick()
    {
        Application.Quit();
    }

    public void onExitMenuClick()
    {
        mainMenu.SetActive(true);
        exitButton.SetActive(false);
        cameraController.GetComponent<CameraController>().canMove = false;
        camera.GetComponent<MainGame>().clearBoard();
    }
}
