using UnityEngine;

public class MenuController : MonoBehaviour
{

    public void LoadScores() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scores");
    }

    public void LoadLevel1() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
