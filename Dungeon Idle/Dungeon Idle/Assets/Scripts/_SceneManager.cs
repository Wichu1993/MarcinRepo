using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{

    public void LoadScene(string nazwa) {
        SceneManager.LoadScene(nazwa);
    }

    public void _Quit() {
        Application.Quit();
    }
}
