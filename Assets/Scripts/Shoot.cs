using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject prefab;
    public ParticleSystem particle;
    public Text scoreText;
    int score = 0;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        scoreText.text = "Score : " + score;
    }
    public void Fire()
    {
        RaycastHit hit;
        particle.Play();
        if (Physics.Raycast(arCamera.transform.position,
                            arCamera.transform.forward, out hit))
        {
            if (hit.transform.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab, hit.point,
                            Quaternion.LookRotation(hit.normal));
                score++;
            }
        }
    }
}
