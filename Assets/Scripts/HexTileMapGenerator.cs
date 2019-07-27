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

    //Number
    private int count = 0;

    //================================ Methods

    void Start()
    {
        CreateHexTileMap();
    }

    void CreateHexTileMap()
    {
        for(int x = 0; x <= mapWidth; x++)
        {
            for(int z = 0; z <= mapLength; z++)
            {
                GameObject TemporaryGameObject = Instantiate(hexTilePrefab);

                if(z % 2 == 0)
                {
                    TemporaryGameObject.transform.position = new Vector3(x * tileXOffset, 0, z * tileZOffset );
                    TemporaryGameObject.GetComponent<HexTile>().SetHexCoordinates(HexCoordinates.FromOffsetCoordinates(x, z));
                }
                else
                {
                    TemporaryGameObject.transform.position = new Vector3(x * tileXOffset + tileXOffset / 2, 0, z * tileZOffset);
                    TemporaryGameObject.GetComponent<HexTile>().SetHexCoordinates(HexCoordinates.FromOffsetCoordinates(x, z));
                }
                SetTileInfo(TemporaryGameObject);
                count++;
            }
        }
    }

    void SetTileInfo(GameObject GO)
    {
        GO.transform.parent = transform;
        GO.GetComponent<HexTile>().SetHexTileName("Hextile " + count);
        GO.GetComponent<HexTile>().SetBuildable(true);
        GO.GetComponent<HexTile>().SetEmpty(true);
        GO.name = ("Hextile " + count);
    }
}
