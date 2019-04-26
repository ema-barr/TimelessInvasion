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
    [SerializeField]
    private GameObject[] elementsToDeactivate;
    

    public void EnablePanel()
    {
        gameOverPanel.SetActive(true);

        foreach(GameObject el in elementsToDeactivate)
        {
            el.SetActive(false);
        }
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