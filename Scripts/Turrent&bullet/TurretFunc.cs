using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurretFunc : MonoBehaviour
{
    public float Range;
    bool Detected = false;
    Vector2 Direction;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(Player.position, transform.position);
        if (distanceFromPlayer < Range)
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }


        }
       
    }
    void shoot()
    {
        var BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
