 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//Script controls all functions of the rocket
public class Rocket : MonoBehaviour
{
    //Rotation speed of the rocket
    [SerializeField] float rotationSpeed = 250f;
    //Boost speed of the rocket
    [SerializeField] float rocketSpeed = 25f;
    Rigidbody rb;
    //Audio source for when rocket boosts
    [SerializeField] AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Method controls the rocket
        moveRocket();
        //Updates volume from the sliders
        changeRocketVolume();
    }

    //Provides control for the rocket
    private void moveRocket()
    {
        float rotationSpeed = this.rotationSpeed * Time.deltaTime;

        //Rotate left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        //Rotate right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }

        //Boost ship
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * rocketSpeed);
            //If audio is not already playing
            if (!audio.isPlaying)
                audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }

    //Sets the Audio volume
    public void changeRocketVolume()
    {
        audio.volume = PlayerPrefs.GetFloat("SoundPref");
    }

    //Method is called when rocket collides with something
    void OnCollisionEnter(Collision collision)
    {
        if(string.Equals(collision.gameObject.tag, "Level1"))
        {
            SceneManager.LoadScene(1); //loads the second level
        }
        else if(string.Equals(collision.gameObject.tag, "Level2"))
        {
            SceneManager.LoadScene(4); //loads the third level
        }
        else if(string.Equals(collision.gameObject.tag, "EndGame"))
        {
            SceneManager.LoadScene(3); //loads the victory game scene
        }
        else if(string.Equals(collision.gameObject.tag, "LaunchPad"))
        {
        //Collision with starting launchpad does nothing
        }
        else
            SceneManager.LoadScene(5);
        //Collision with obstacle loads failure screen
    }
}
