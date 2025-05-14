using UnityEngine;

public class ImageMapping : MonoBehaviour
{
    [SerializeField] private Texture2D _imageLayout;
    [SerializeField] private ColorToPrefabMapping[] _mappings;
    [SerializeField] private int _pixelPerUnit = 1;
    
    private Color[] _pixels => _imageLayout.GetPixels();
    
    
    private void Start()
    {
        SpawnObjects(GetSpawnPoints(), _mappings);
    }

    private void SpawnObjects(Vector3[] spawnPositions, ColorToPrefabMapping[] mappings)
    {
        int columns = _imageLayout.width / _pixelPerUnit;
        int rows = _imageLayout.height / _pixelPerUnit;
        int pixelArea = _pixelPerUnit * _pixelPerUnit;

        int rowJump = pixelArea * columns;
        int rowLimit = (rows - 1) * rowJump;
        int columnLimit = ((columns - 1) * _pixelPerUnit);
        
        int positionCounter = 0;

        for (int row = 0; row <= rowLimit; row = row + rowJump) 
        {
            for (int column = 0; column <= (columnLimit); column = column + _pixelPerUnit) 
            {
                Color color = _pixels[row + column];
                
                foreach (ColorToPrefabMapping mapping in mappings)
                {
                    if (color.Equals(mapping.Color))
                    {
                        Vector3 position = new Vector3( spawnPositions[positionCounter].x, mapping.YOffset, spawnPositions[positionCounter].z);
                        Instantiate(mapping.GameObject, position, Quaternion.identity);
                    }
                }
                
                positionCounter++;
            }
        }
        
    }
    
    private Vector3[] GetSpawnPoints()
    {
        int worldX = _imageLayout.width/_pixelPerUnit;
        int worldZ = _imageLayout.height/_pixelPerUnit;

        Vector3[] spawnPositions = new Vector3[worldX * worldZ];
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
