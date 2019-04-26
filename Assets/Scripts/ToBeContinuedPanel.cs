using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ToBeContinuedPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject toBeCondinuedText;
    [SerializeField]
    private string mainMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowToBeContinuedCo());
    }

    private IEnumerator ShowToBeContinuedCo()
    {
        yield return new WaitForSeconds(3f);
        toBeCondinuedText.SetActive(true);

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(mainMenuScene);

    }
}
