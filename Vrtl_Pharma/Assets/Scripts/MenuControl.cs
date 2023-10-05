using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartBT()
    {
        SceneManager.LoadScene("mainScene");
    }

    public void MenuBT()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitBT()
    {
        Application.Quit();
    }

}
