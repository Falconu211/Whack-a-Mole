using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionButton : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("NextScene");
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene("FrastScene");
    }
}
