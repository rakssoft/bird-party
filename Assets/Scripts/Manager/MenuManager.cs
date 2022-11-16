using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void BonusGame()
    {
        SceneManager.LoadScene(2);
    }


}
