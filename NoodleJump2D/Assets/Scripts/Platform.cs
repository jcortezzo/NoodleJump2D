using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    // Update is called once per frame
    void Update()
    {
        if (AutoLevelGenerator.Instance.PlayerPosition().y > this.transform.position.y + 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        if (p != null && !p.IsAscending())
        {
            p.Jump(jumpForce);
        }
    }
}
