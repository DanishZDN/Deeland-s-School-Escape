using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pausePanel; // Referensi ke Panel Pause
    private bool isPaused = false; // Status game

    // Fungsi untuk toggle pause menu (ESC atau tombol Pause)
    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; // Pause atau resume waktu
    }

    // Fungsi untuk melanjutkan game
    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1; // Kembali ke normal
    }

    // Fungsi untuk membuka Settings (placeholder)
    public void OpenSettings()
    {
        Debug.Log("Settings menu opened.");
    }

    // Fungsi untuk kembali ke Menu Utama
    public void ReturnToMenu()
    {
        Time.timeScale = 1; // Pastikan waktu normal
        SceneManager.LoadScene("MainMenu"); // Ganti "MainMenu" dengan nama scene menu Anda
    }

    public void TestFunction()
    {
        Debug.Log("TestFunction is called!");
    }
}