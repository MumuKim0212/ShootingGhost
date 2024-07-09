using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float curHealth; //* ���� ü��
    public float maxHealth = 100f; //* �ִ� ü��
    public GameObject getshoot;
    AudioSource source;
    Shoot shoot;
    public AudioClip audioClip;
    public AudioClip damageClip;

    [Header("Text")]
    public Text bestScoreText;          // ������ ����� UI �ؽ�Ʈ
    public GameObject gameoverUI;       // ���� ������ Ȱ��ȭ �� UI ���� ������Ʈ
    public GameObject crossline;       // ���� ������ Ȱ��ȭ �� UI ���� ������Ʈ
    private float bestScore;
    public bool isGameover = false;     // ���� ���� ����

    private void Start()
    {
        SetHp(100);
        CheckHp();
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetHp(float amount) //*Hp����
    {
        maxHealth = amount;
        curHealth = maxHealth;
    }
    public Slider HpBarSlider;

    public void CheckHp() //*HP ����
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth / maxHealth;
    }

    public void Damage(float damage) //* ������ �޴� �Լ�
    {
        source.PlayOneShot(damageClip);
        if (maxHealth == 0 || curHealth <= 0) //* �̹� ü�� 0���ϸ� �н�
            return;
        curHealth -= damage;
        CheckHp(); //* ü�� ����
        if (curHealth <= 0)
        {
            gameoverUI.SetActive(true);
            OnPlayerDead();
            crossline.SetActive(false);
        }
    }
    public void OnPlayerDead()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        isGameover = true;
        source.PlayOneShot(audioClip);

        shoot = getshoot.GetComponent<Shoot>();
        if (shoot.score > bestScore)
        {
            bestScore = shoot.score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        bestScoreText.text = "BestScore : " + bestScore;
        gameoverUI.SetActive(true);
    }
}
