using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{
    [SerializeField] private int GameSceneIndex;
    [SerializeField] private int MainMenuSceneIndex;
    [SerializeField] private AudioMixer audioMixer;

    private bool isMuted = false;

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

    public void ToggleMute()
    {
        if (isMuted)
        {
            audioMixer.SetFloat("MasterVolume", 0f);
        }
        else
        {
            audioMixer.SetFloat("MasterVolume",-80f);
        }

        isMuted = !isMuted;
    }

}
