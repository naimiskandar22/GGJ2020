using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonFunc : MonoBehaviour
{
 
    public void restartScene()
    {
        //SceneManager.LoadScene("Gameplay");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void backToMenuScene()
    {
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
