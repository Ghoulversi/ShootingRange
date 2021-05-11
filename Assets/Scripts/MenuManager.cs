using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Load GameScene
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }


    public void ExitGame()
    {
        /*
#if UNITY_EDITOR
        Application.Quit();
#endif

#if PLATFORM_ANDROID
        System.Diagnostics.Process.GetCurrentProcess().Kill();
#endif
*/

    }
}
