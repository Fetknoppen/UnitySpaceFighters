using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    public GameObject Bullet_Emitter;

    public GameObject Bullet;

    public float Bullet_Forward_Force;

    public GameObject BulletTarget;


    private Rigidbody2D myRigidbody;
     
    public GameObject thePlayer;

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

        if (Input.GetKey(KeyCode.A))
        {
            thePlayer.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            thePlayer.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            float step = thrust * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            myAnimator.SetBool("Thrust", true);
        }


        //Shoot
        if (Input.GetKeyDown(KeyCode.V))
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

        if (other.gameObject.tag == "InstantDeath")
        {

            myRigidbody.velocity = new Vector3(0, 0, 0);

            transform.position = new Vector3(-7, 0, 0);
        }
    }
}
