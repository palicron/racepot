using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidzone : MonoBehaviour {
    public float speedboos;
    public int topbost;
    private int oldtopseepd;
    private float oldace;
    private GameObject player;
    private bool ac;
    private void Start()
    {
        player = GameObject.Find("Player");
        ac = false;
    }
    public void Update()
    {
        if(ac)
            player.gameObject.GetComponent<control>().forceacelaration();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Equals("Player"))
        {
            oldtopseepd = collision.gameObject.GetComponent<control>().Gettop();
            oldace = collision.gameObject.GetComponent<control>().Getacceleration();
            collision.gameObject.GetComponent<control>().Settop(topbost);
            collision.gameObject.GetComponent<control>().SetAcceleration(speedboos);
            ac = true;
            collision.gameObject.GetComponent<control>().setgrounded(false);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {

            collision.gameObject.GetComponent<control>().Settop(oldtopseepd);
            collision.gameObject.GetComponent<control>().SetAcceleration(oldace);
            ac = false;
            collision.gameObject.GetComponent<control>().setgrounded(true);
        }
    }
}
