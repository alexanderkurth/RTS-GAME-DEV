using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTileMapGenerator : MonoBehaviour
{
    //================================ Variables

    //Hexagon Prefab
    public GameObject hexTilePrefab;

    //Map dimension
    [SerializeField]int mapWidth = 25;
    [SerializeField]int mapLength = 12;

    //Space between tiles 
    [SerializeField] float tileXOffset = 1.8f;
    [SerializeField] float tileZOffset = 1.565f;

    //================================ Methods

    void Start()
    {
        CreateHexTileMap();
    }

    void CreateHexTileMap()
    {
        for(int x = 1; x <= mapWidth; x++)
        {
            for(int z = 1; z <= mapLength; z++)
            {
                GameObject TemporaryGameObject = Instantiate(hexTilePrefab);
                HexTile TemporaryHexTile;

                if(z % 2 == 0)
                {
                    TemporaryGameObject.transform.position = new Vector3(x * tileXOffset, 0, z * tileZOffset );
                    TemporaryHexTile = new HexTile(x * tileXOffset, 0, z * tileZOffset);
                }
                else
                {
                    TemporaryGameObject.transform.position = new Vector3(x * tileXOffset + tileXOffset / 2, 0, z * tileZOffset);
                    TemporaryHexTile = new HexTile(x * tileXOffset + tileXOffset / 2, 0, z * tileZOffset);
                }
                SetTileInfo(TemporaryGameObject, TemporaryHexTile);
            }
        }
    }

    void SetTileInfo(GameObject GO, HexTile HT)
    {
        GO.transform.parent = transform;
        GO.name = HT.CoordinateToString() ;
        HT.SetName(GO.name);
    }

}
