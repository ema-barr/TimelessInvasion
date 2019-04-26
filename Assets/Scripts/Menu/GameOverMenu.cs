using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private string mainMenu;
    [SerializeField]
    private string sceneToRetry;
    

    public void EnablePanel()
    {
        gameOverPanel.SetActive(true);
    }



    public void Retry()
    {
        SceneManager.LoadScene(sceneToRetry);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
 
}