using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Gun : MonoBehaviourPun
{
    public GameObject bulletPrefab;
    public float fireInterval = 0.5f;
    public float nextFire = 0.0f;
    public Transform muzzleTransform;


    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine && PhotonNetwork.IsConnected)
            return;
            
        if (Input.GetMouseButton(0) && Time.time > nextFire){
            nextFire = Time.time + fireInterval;
            GameObject bullet = Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        }
    }
}
