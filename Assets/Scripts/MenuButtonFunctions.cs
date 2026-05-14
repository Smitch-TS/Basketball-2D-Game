using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{
    [SerializeField] private int GameSceneIndex;
    [SerializeField] private int MainMenuSceneIndex;

    public void LoadGame()
    {
        SceneManager.LoadScene(GameSceneIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneIndex);
    }

    public void ExitApplication()
    {
        #if UNITY_EDITOR
            // This stops Play Mode in the Editor
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // This closes the actual built application
            Application.Quit();
        #endif
    }

}
