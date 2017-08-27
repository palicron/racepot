using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {

    [SerializeField] private bool alive;
    public float Acceleration;
    public float Turnspeed;
    public int topspeed;
    public int topturnspeed;
    public ForceMode Accelforce;
    public ForceMode Turnforce;
    public ForceMode jumpforce;
    private Rigidbody rb;
    private CharacterController cont;
    private Transform trans;
    [SerializeField] private float vel;
    [SerializeField] private float velT;
    [SerializeField] private bool grounded;
    public GameObject particols;
    private Collider[] grc;
    private bool acel;
    private bool jump;
    private bool bturn;
    private int turn;
    public LayerMask whatisground;
    private bool can;
    private void Awake()
    {
        alive = true;
    }
    void Start () {
     
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        cont = GetComponent<CharacterController>();
        acel = false;
        jump = false;
        turn = 0;
        bturn = false;
        can = true;


    }
	
	// Update is called once per frame
	void Update () {

        if (!alive)
            return;
        
        vel = Mathf.Abs(rb.velocity.z);
        velT = rb.velocity.x;
        grc = Physics.OverlapSphere(GetComponent<Transform>().position, 10f, whatisground);
        if (grc.Length != 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if(Input.GetKey("z"))
        {
            if (vel < topspeed)
            {
                rb.AddForce(Vector3.forward * -Acceleration, Accelforce);
            }
            particols.SetActive(true);
        }
        else
        {
            particols.SetActive(false);
        }
        if (Input.GetKeyDown("x") && grounded && can)
        {
            rb.AddForce(Vector3.up * 10, jumpforce);
        }
        if (Input.GetButton("Horizontal"))
        {
          
            if (Input.GetAxis("Horizontal") > 0)
            {
               turn = 1;
               // trans.Rotate(new Vector3(0,0,1) * -10* Time.deltaTime);
                trans.position += Vector3.right * ((-Turnspeed - (vel*0.1f) ) * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                turn = -1;
             //   trans.Rotate(new Vector3(0, 0, 1) * 10 * Time.deltaTime);
                trans.position += Vector3.right * ((Turnspeed + (vel * 0.1f) )*  Time.deltaTime);
            }
        }



    
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            grounded = true;
        }
    }
    public void forceacelaration()
    {
        if (vel < topspeed)
        {
            rb.AddForce(Vector3.forward * -Acceleration, Accelforce);
        }
        particols.SetActive(true);
    }

    //Getter and setters

    public void SetAlive(bool st)
    {
        alive = st;
    }
    public int Gettop()
    {
        return topspeed;
    }
    public void Settop(int newspeed)
    {
        topspeed = newspeed;
    }
    public void SetAcceleration(float newacelspeed)
    {
        Acceleration = newacelspeed;
    }
    public float Getacceleration()
    {
        return Acceleration;
    }
    public void setgrounded(bool b)
    {
        can = b;
    }
}
