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
        // 오디오 재생 로직
    }
    // 게임 상태 관리
    public void StartGame()
    {
        // 게임 시작 로직
    }

    public void EndGame()
    {
        // 게임 종료 로직
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
