using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadblock : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<control>().SetAlive(false);
        }
    }
}
