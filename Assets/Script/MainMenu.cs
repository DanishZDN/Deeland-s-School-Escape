using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public enum ButtonAction
    {
        PlayGame,
        QuitGame
    }

    public ButtonAction action;

    public void OnButtonClick()
    {
        switch (action)
        {
            case ButtonAction.PlayGame:
                PlayGame();
                break;
            case ButtonAction.QuitGame:
                QuitGame();
                break;
        }
    }

    private void PlayGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            SceneManager.LoadScene("Tutorial");
        }
        else if (currentScene.name == "Tutorial")
        {
            SceneManager.LoadScene("NextStage");
        }
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}