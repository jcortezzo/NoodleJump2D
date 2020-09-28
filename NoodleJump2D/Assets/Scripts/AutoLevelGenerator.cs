using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLevelGenerator : MonoBehaviour
{
    public static AutoLevelGenerator Instance;

    [SerializeField] private GameObject normalPlatformPrefab;
    [SerializeField] private Player player;
    [SerializeField] private int yOffset;
    [SerializeField] private float platformWidth;

    [SerializeField] private GameObject enemyPrefab;
    [Range(0f, 1f)]
    [SerializeField] private float spawnChance; 
    private Vector2 previousPosition;

    public void Awake()
    {
        if(Instance == null) { Instance = this; }
    }
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
        int platforms = Random.Range(10, 20);
        while(platforms > 0)
        {
            int randX = Random.Range(1, 4);
            float x = -8;
            while(randX > 0)
            {
                x += (Random.Range(0f, 3f) + platformWidth);
                Vector2 position = new Vector2(x, previousPosition.y);
                if(Random.Range(0f, 1f) < 0.2f && position.y > player.transform.position.y) Instantiate(enemyPrefab, position + Vector2.up, Quaternion.identity);
                Instantiate(normalPlatformPrefab, position, Quaternion.identity);
                platforms--;
                randX--;
            }
            previousPosition = new Vector2(previousPosition.x , previousPosition.y + Random.Range(1f, yOffset));
        }
    }

    public Vector3 PlayerPosition()
    {
        return player.transform.position;
    }
}
