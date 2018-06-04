﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Controller : MonoBehaviour
{

    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float Bullet_Forward_Force;

    public GameObject BulletTarget;



    public GameObject thePlayer;

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    public int rotationSpeed;

    public float thrust;
    public Transform target;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();



    }


    void Update()
    {
        myAnimator.SetBool("Thrust", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            thePlayer.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            thePlayer.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float step = thrust * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            myAnimator.SetBool("Thrust", true);
        }


        //Shoot
        if (Input.GetKeyDown(KeyCode.M))
        {


            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;


            Rigidbody2D Temporary_Rigidbody2D;
            Temporary_Rigidbody2D = Temporary_Bullet_Handler.GetComponent<Rigidbody2D>();


            Temporary_Rigidbody2D.AddForce(BulletTarget.transform.position * Bullet_Forward_Force);


            Destroy(Temporary_Bullet_Handler, 2.0f);
        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        bool RedHeart3 = GameObject.FindGameObjectWithTag("RH3");
        bool RedHeart2 = GameObject.FindGameObjectWithTag("RH2");
        bool RedHeart1 = GameObject.FindGameObjectWithTag("RH1");


        if (other.gameObject.tag == "InstantDeath")
        {
            myRigidbody.velocity = new Vector3(0, 0, 0);

            transform.position = new Vector3(7, 0, 0);




            GameObject[] gameObjectArray3 = GameObject.FindGameObjectsWithTag("RH3");
            foreach (GameObject go in gameObjectArray3)
            {
                go.SetActive(false);
            }

            if (RedHeart3 == false)
            {
                GameObject[] gameObjectArray2 = GameObject.FindGameObjectsWithTag("RH2");
                foreach (GameObject go in gameObjectArray2)
                {
                    go.SetActive(false);
                }
            }

            if (RedHeart3 == false && RedHeart2 == false)
            {

                GameObject[] gameObjectArray1 = GameObject.FindGameObjectsWithTag("RH1");
                foreach (GameObject go in gameObjectArray1)
                {
                    go.SetActive(false);
                }

                SceneManager.LoadScene("BlueWinScreen");
            }



        }
    }
}
