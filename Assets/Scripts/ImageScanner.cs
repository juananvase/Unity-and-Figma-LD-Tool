using UnityEngine;

public class ImageScanner : MonoBehaviour
{
    [SerializeField] private Texture2D _imageLayout;
    [SerializeField] private ColorToPrefabMapping[] _mappings;
    
    private Color[] _pixels => _imageLayout.GetPixels();
    
    private void Start()
    {
        SpawnObjects(GetSpawnPoints(_pixels.Length), _mappings);
        
    }

    private void SpawnObjects(Vector3[] spawnPositions, ColorToPrefabMapping[] mappings)
    {
        int counter = 0;

        foreach (Vector3 position in spawnPositions)
        {
            Color color = _pixels[counter];
            
            foreach (ColorToPrefabMapping mapping in mappings)
            {
                if (color.Equals(mapping.Color))
                {
                    Instantiate(mapping.GameObject, position, Quaternion.identity);
                }
            }
            
            counter++;
        }
    }

    private Vector3[] GetSpawnPoints(int length)
    {
        int worldX = _imageLayout.width;
        int worldZ = _imageLayout.height;

        Vector3[] spawnPositions = new Vector3[length];
        Vector3 startSpawnPosition = new Vector3(-Mathf.Round(worldX/2), 0, -Mathf.Round(worldZ/2));
        Vector3 currentSpawnPosition = startSpawnPosition;
        
        int counter = 0;

        for (int z = 0; z < worldZ; z++)
        {
            for (int x = 0; x < worldX; x++)
            {
                spawnPositions[counter] = currentSpawnPosition;
                counter++;
                currentSpawnPosition.x++;
            }
            
            currentSpawnPosition.x = startSpawnPosition.x; 
            currentSpawnPosition.z++;
        }
        
        return spawnPositions;
    }
}
