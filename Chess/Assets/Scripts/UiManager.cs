using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Camera camera;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject cameraController;
    public GameObject exitButton;
    public GameObject gameOverText;

    public void notifyGameOver(string message)
    {
        gameOverText.SetActive(true);
        gameOverText.GetComponent<Text>().text = message;
    }

    public void onPlayClick()
    {
        mainMenu.SetActive(false);
        camera.GetComponent<MainGame>().beginGame();
        cameraController.GetComponent<CameraController>().canMove = true;
        exitButton.SetActive(true);
    }

    public void onSettingsClick()
    {
        //mainMenu.SetActive(false);
        //settingsMenu.SetActive(true);
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
        gameOverText.SetActive(false);
    }
}
