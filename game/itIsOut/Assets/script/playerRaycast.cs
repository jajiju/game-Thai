using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    private player player;
    public bool hit;
    public BoxCollider2D foot;

    void Start()
    {
        player = gameObject.GetComponentInParent<player>();
        foot = GameObject.Find("gCheck").GetComponent<BoxCollider2D>();
    } 

    void Update()
    {
        hit = Physics.Raycast(foot.transform.position, Vector3.back, 30);
        if (Physics.Raycast(foot.transform.position, Vector3.back, 30)) player.cl2d.enabled = true; else player.cl2d.enabled = false;
        Debug.Log(foot.transform.position);
    }
}
