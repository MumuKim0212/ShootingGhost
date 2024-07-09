using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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
    public void PlaySound(AudioClip clip)
    {
        // ����� ��� ����
    }
    // ���� ���� ����
    public void StartGame()
    {
        // ���� ���� ����
    }

    public void EndGame()
    {
        // ���� ���� ����
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
