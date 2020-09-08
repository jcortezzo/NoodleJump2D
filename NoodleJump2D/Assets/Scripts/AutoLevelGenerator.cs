using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLevelGenerator : MonoBehaviour
{
    public static AutoLevelGenerator Instance;

    [SerializeField] private GameObject normalPlatformPrefab;
    [SerializeField] private Player player;
    [SerializeField] private int yOffset;

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
        for(int i = 0; i < platforms; i++)
        {
            Vector2 position = new Vector2(Random.Range(-4, 4), previousPosition.y + Random.Range(0, yOffset));
            Instantiate(normalPlatformPrefab, position, Quaternion.identity);
            previousPosition = position;
        }
    }

    public Vector3 PlayerPosition()
    {
        return player.transform.position;
    }
}
