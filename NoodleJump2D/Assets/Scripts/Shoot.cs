using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Camera cam;
    [SerializeField] Bullet bullet;
    [SerializeField] float bulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 dir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            Bullet b = Instantiate<Bullet>(bullet, transform.position, Quaternion.identity);
            b.Shoot(dir.normalized * bulletSpeed);
        }
    }
}
