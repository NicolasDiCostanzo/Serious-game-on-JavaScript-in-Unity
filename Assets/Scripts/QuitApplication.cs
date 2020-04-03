using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    public void QuitApp()
    {
        Debug.Log("ApllicationQuit");
        Application.Quit();
    }
}
