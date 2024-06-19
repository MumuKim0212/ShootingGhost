using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject prefab;
    public ParticleSystem particle;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Fire()
    {
        RaycastHit hit;
        particle.Play();
        if (Physics.Raycast(arCamera.transform.position,
                            arCamera.transform.forward, out hit))
        {
            if(hit.transform.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
                Instantiate(prefab, hit.point,
                            Quaternion.LookRotation(hit.normal));
            }
        }
    }
}
