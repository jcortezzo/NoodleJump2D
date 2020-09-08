using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null) Debug.Log(p.GetComponent<Rigidbody2D>().velocity.y);
        if (p != null && !p.IsAscending())
        {
            p.Jump(jumpForce);
        }
    }
}
