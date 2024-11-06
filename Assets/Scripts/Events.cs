using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Events : MonoBehaviour
{
    [SerializeField]
    GameObject StartGamePanel;
    [SerializeField]
    GameObject PauseMenuPanel;
    [SerializeField]
    GameObject OptionsPanel;
    [SerializeField]
    GameObject HowToPlayPanel;
    [SerializeField]
    GameObject CreditsPanel;
    [SerializeField] 
    TMP_Text muteButtonText;

    public void MainMenu()
    {
        SceneManager.LoadScene("Scene2");
        PlayerManager.gameOver = false;
        Player.gameStarted = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Scene2");
        PlayerManager.gameOver = false;
        Player.restarting = true;
        StartGame();
    }
    public void StartGame() {
        StartGamePanel.SetActive(false);
        Player.gameStarted = true;
    }
   
    public void ResumeGame()
    {
        Player.speedValue = Player.speedbeforepause;
        Player.isPaused = false;
        PauseMenuPanel.SetActive(false); // Hide the pause menu
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    public void Options() {
        OptionsPanel.SetActive(true);
    }
    public void CloseOptions()
    {
        OptionsPanel.SetActive(false);
    }
    public void HowToPlay()
    {
        HowToPlayPanel.SetActive(true);
    }
    public void CloseHowToPlay()
    {
        HowToPlayPanel.SetActive(false);
    }
    public void Credits()
    {
        CreditsPanel.SetActive(true);
    }
    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
    }
    public void MuteSound()
    {
        // mute all music
        Player.muted = !Player.muted;
        if (Player.muted)
        {
            muteButtonText.SetText("Unmute Sound");
        }
        else
        {
            muteButtonText.SetText("Mute Sound");
        }
    }
}
