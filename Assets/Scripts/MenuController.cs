
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public string levelSceneName = "Level1";

    public void StartGame()
    {
        // Reiniciar score ao iniciar
        if (GameManager.Instance != null)
            GameManager.Instance.ResetScore();

        SceneManager.LoadScene(levelSceneName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}