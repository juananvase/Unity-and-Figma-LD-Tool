using UnityEngine;

[System.Serializable]
public struct ColorToPrefabMapping
{
    [field: SerializeField] public GameObject GameObject { get; private set; }
    [field:SerializeField] public Color Color { get; private set; }
    [field:SerializeField] public float YOffset { get; private set; }
    
    public ColorToPrefabMapping(GameObject gameObject, Color color, float yOffset)
    {
        this.GameObject = gameObject;
        this.Color = color;
        this.YOffset = yOffset;
    }
}
