using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cd : MonoBehaviour {

    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<control>().SetAlive(false);
    }
}
