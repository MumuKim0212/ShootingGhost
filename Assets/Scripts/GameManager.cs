using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menu;

    public void OpenMenu()
    {
        menu.SetActive(true);
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
