using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWonMenu : MonoBehaviour
{
  public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

  public void ExitGame()
    {
        Application.Quit();
    }
}
