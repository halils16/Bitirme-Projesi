using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour
{
    public AudioSource hornSound;
    public AudioSource source;
     

    public float duzeltmeHizi;
    public float minPitch;
    public float pitchHizi;

    private float hiz;

    public static CarSound instance;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Horn();
        CarDrive();
        

        hiz = GetComponent<CarController>().speed;

    }

    private void Horn()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hornSound.Play();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            hornSound.Stop();
        }
    }

    private void CarDrive()
    {
        source.pitch = Mathf.Lerp(source.pitch, minPitch + Mathf.Abs(hiz) / duzeltmeHizi, pitchHizi);

    }

   
}
