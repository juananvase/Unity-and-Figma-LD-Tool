using Unity.VisualScripting;
using UnityEngine;

public class ImageScanner : MonoBehaviour
{
    [SerializeField] private Texture2D _imageLayout;

    private void Start()
    {
        Color[] px = _imageLayout.GetPixels();

        int black = 0;
        int white = 0;

        foreach (Color color in px)
        {
            if (color.Equals(Color.white))
            {
                white++;
            }
            else if (color.Equals(Color.black))
            {
                black++;
            }

            Debug.Log("White = "+white);
            Debug.Log("Black = "+black);
        }
    }

}
