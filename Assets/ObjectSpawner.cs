using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Assign the Cube Prefab here
    public int cubeCount = 30;    // Number of cubes to spawn
    public Terrain terrain;       // Assign the terrain object

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            // Get random x and z positions within the terrain
            float terrainWidth = terrain.terrainData.size.x;
            float terrainLength = terrain.terrainData.size.z;

            float posX = Random.Range(0, terrainWidth);
            float posZ = Random.Range(0, terrainLength);

            // Get the terrain height at that x/z position
            float terrainHeight = terrain.SampleHeight(new Vector3(posX, 0, posZ));

            // Spawn the cube at this position
            Vector3 spawnPosition = new Vector3(posX, terrainHeight + 1f, posZ);
            Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
