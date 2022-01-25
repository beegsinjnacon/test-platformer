using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantWall : MonoBehaviour
{
    public GameObject block; // Set in Unity
    public int width = 10;
    public int height = 4;
    void Start()
    {
        for (int yy = 0; yy < height; yy++)
        {
            for (int xx = 0; xx < width; xx++)
            {
                Vector3 offset = new Vector3(xx, yy+1, 0);
                Instantiate(block, transform.position + offset, Quaternion.identity);
            }
        }
    }
}
