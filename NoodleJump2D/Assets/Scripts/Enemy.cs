using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Start()
    {
        int rand = Random.Range(1, 7);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/enemy" + rand);
    }

    // Update is called once per frame
    void Update()
    {
        if (AutoLevelGenerator.Instance.PlayerPosition().y > this.transform.position.y + 10)
        {
            Destroy(this.gameObject);
        }
    }
}
