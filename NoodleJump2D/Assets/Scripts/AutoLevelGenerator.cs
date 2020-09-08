using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject normalPlatformPrefab;
    [SerializeField] private Player player;
    [SerializeField] private float yOffset;

    private Vector2 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y > previousPosition.y - (3 * 5))
        {
            GeneratePlatforms();
        }
    }

    private void GeneratePlatforms()
    {
        int platforms = 10;
        for(int i = 0; i < platforms; i++)
        {
            Vector2 position = new Vector2(Random.Range(-2, 2), previousPosition.y + yOffset);
            Instantiate(normalPlatformPrefab, position, Quaternion.identity);
            previousPosition = position;
        }
    }

}
