using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;

    public Material mainMaterial;
    public Material additionalMaterial;

    public void ColorChildren()
    {
        foreach (Transform child in transform)
        {
            if(child.tag == "Wall")
            {
                if (Random.Range(0, 3)==0)
                {
                    child.gameObject.GetComponent<Renderer>().material = additionalMaterial;
                }
                else
                {
                    child.gameObject.GetComponent<Renderer>().material = mainMaterial;

                }
            }
        }
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);
        if (pixelColor.a == 0) return;
        foreach (var c in colorMappings)
        {
            if (c.color.Equals(pixelColor))
            {
                Vector3 pos = new Vector3(x, 0, z) * offset;
                Instantiate(c.prefab, pos, Quaternion.identity, transform);
            }
        }
    }

    public void GenerateLabirynth()
    {
        for (int x=0; x<map.width; x++)
        {
            for (int z=0; z<map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
        ColorChildren();
    }
}
