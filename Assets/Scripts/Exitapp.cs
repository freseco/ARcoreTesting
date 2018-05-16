using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitapp : MonoBehaviour {

	public void ExitofThisapp()
    {
        Application.Quit();
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene(0);
    }
}
