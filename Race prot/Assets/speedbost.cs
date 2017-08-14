using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedbost : MonoBehaviour {

    public float speedboos;
    public int topbost;
    private int oldtopseepd;
    private float oldace;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
           oldtopseepd = collision.gameObject.GetComponent<control>().Gettop();
            oldace = collision.gameObject.GetComponent<control>().Getacceleration();
            collision.gameObject.GetComponent<control>().Settop(topbost);
            collision.gameObject.GetComponent<control>().SetAcceleration(speedboos);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            
            collision.gameObject.GetComponent<control>().Settop(oldtopseepd);
            collision.gameObject.GetComponent<control>().SetAcceleration(oldace);
        }
    }
}
