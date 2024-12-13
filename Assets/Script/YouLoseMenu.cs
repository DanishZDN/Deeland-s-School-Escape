using UnityEngine;
using UnityEngine.SceneManagement;

public class YouLoseMenu : MonoBehaviour
{
   public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
