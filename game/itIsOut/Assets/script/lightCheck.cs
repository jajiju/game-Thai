using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCheck : MonoBehaviour {
        public float distance;
        private player player;
        private Light lsrc;

        void Start()
        {
            player = GameObject.Find("factoryWorker").GetComponent<player>();
            lsrc = gameObject.GetComponent<Light>();
        }

        void Update()
        {
            distance = Vector3.Distance(player.rb2d.transform.position, lsrc.transform.position);
            if (distance < (30 / Mathf.Cos((45 / 2 * Mathf.PI) / 180))) player.cl2d.enabled = true; else player.cl2d.enabled = false;
        }
}
