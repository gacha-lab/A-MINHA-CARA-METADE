using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Publico : MonoBehaviour
    {
    private bool isFollowinga;
    public float followSpeed;
    public Transform followTarget2;

    void Start()
    {
        
    }

    void Update()
    {
        if (isFollowinga)
        {
            transform.position = Vector3.Lerp(transform.position, followTarget2.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D another)
    {
        if (another.tag == "Player2")
        {
            if (!isFollowinga)
            {
                FindObjectOfType<Audio_Manager>().Play("Key");
                PlayerController2 Player2 = FindObjectOfType<PlayerController2>();

                followTarget2 = Player2.KeyFollowPoint;

                isFollowinga = true;
                Player2.followingKe = this;
            }
        }
    }
}