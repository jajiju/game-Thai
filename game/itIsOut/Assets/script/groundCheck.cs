using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour {
    private player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (player.cl2d.enabled) player.grounded = true; else player.grounded = false;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.cl2d.enabled) player.grounded = true; else player.grounded = false;
    }
}
