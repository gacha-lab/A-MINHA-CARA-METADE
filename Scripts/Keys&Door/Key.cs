using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update

    //key

    private bool isFollowing;
    public float followSpeed;
    public Transform followTarget;
    //public Transform followTarget2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)

        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
           

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!isFollowing)
            {
                FindObjectOfType<Audio_Manager>().Play("Key");
                PlayerController Player = FindObjectOfType<PlayerController>();

                followTarget = Player.KeyFollowPoint;

                isFollowing = true;
                Player.followingKey = this;
            }
        }


        //if (other.tag == "Player2")
        //{
        //    if (!isFollowing)
        //    {
        //            FindObjectOfType<Audio_Manager>().Play("Key");
        //            PlayerController2 Player2 = FindObjectOfType<PlayerController2>();

        //            followTarget2 = Player2.KeyFollowPoint;

        //            isFollowing = true;
        //            Player2.followingKey = this;
        //    }
        //}
    }
}
