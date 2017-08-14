using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camarafollo : MonoBehaviour {

    public GameObject camarafocus;
    private Transform trans;
    public float offset;
	// Use this for initialization
	void Start () {


        trans = GetComponent<Transform>();
       
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = camarafocus.GetComponent<Transform>().position;

        trans.position = new Vector3(pos.x, trans.position.y, pos.z + offset);
	}
}
