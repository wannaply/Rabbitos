using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

    public GameObject particle;
    private Animator mAnimator;
    //public GameObject point;


    private float speed;
    private Vector3 velocity;


    Rigidbody rb;
    bool started;
    bool gameOver;
    bool isWalkingLeft;
    bool isWalkingRight;
    public GameObject point;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        mAnimator = GetComponent<Animator>();

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {


                started = true;
                speed = 3f;

                //transform.Translate(Vector3.forward * speed * Time.deltaTime);
                mAnimator.SetBool("isWalkingLeft", started);
                isWalkingLeft = true;
                mAnimator.speed = 1f;

                GameManager.instance.StartGame();
            }

        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.useGravity = true;
            Camera.main.GetComponent<CameraController>().gameOver = true;
            Destroy(gameObject, 2f);
            GameManager.instance.GameOver();
        }

        Debug.DrawRay(transform.position, new Vector3(0, -0.5f, 0), Color.red);


        if (Input.GetMouseButtonDown(0) && !gameOver)
        {


            SwitchDirections();

            //Debug.Log(mAnimator.speed);
            Debug.Log(speed);




        }



    }

    void SwitchDirections()
    {

        if (isWalkingRight)
        {
            transform.Rotate(0, -90f, 0);
            mAnimator.SetBool("isWalkingLeft", started);


            velocity = Vector3.forward * speed;
            if (speed < 8)
            {
                speed += 0.1f;
            }
            //rb.velocity = new Vector3(0, 0, speed);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            isWalkingLeft = true;
            isWalkingRight = false;
        }
        else if (isWalkingLeft)
        {
            mAnimator.SetBool("isWalkingLeft", started);
            transform.Rotate(0, 90f, 0);
            velocity = Vector3.right * speed;
            if(speed < 8)
            {
                speed += 0.1f;
            }
            
            //rb.velocity = new Vector3(speed, 0, 0);
            //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            isWalkingRight = true;
            isWalkingLeft = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Carrot")
        {
            Instantiate(particle, other.transform.position, Quaternion.identity);
            Instantiate(point, other.transform.position, Quaternion.identity, transform);
            //ShowPoint();
            Destroy(other.gameObject);

            ScoreManager.instance.score += 10;
        }

        void ShowPoint()
        {
           Instantiate(point, other.transform.position, Quaternion.identity, transform);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + velocity * Time.deltaTime);
        Debug.Log(speed);
    }
}
