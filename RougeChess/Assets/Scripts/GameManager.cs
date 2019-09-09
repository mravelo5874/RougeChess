using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int size;
    public GameObject tilePrefab;
    
    public Transform board;
    public ChessTileScript[,] tiles;
    public Material blackTileMaterial;
    public Material whiteTileMaterial;

    public GameObject playerPrefab;
    public Vector2 playerPos;

    public void Start() {
        tiles = new ChessTileScript[size, size];
        bool color = false;

        for (int x = 0; x < size; x++) {
            for (int z = 0; z < size; z++) {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0, z), Quaternion.identity);
                tile.transform.SetParent(board);
                tiles[x, z] = tile.GetComponent<ChessTileScript>();
                tiles[x, z].pos = new Vector2(x, z);

                if (color) {
                    tile.GetComponent<MeshRenderer>().material = blackTileMaterial;
                }
                else {
                    tile.GetComponent<MeshRenderer>().material = whiteTileMaterial;
                }
                color = !color;
            }
        }

        playerPos = new Vector2(0, 0);
        GameObject player = Instantiate(playerPrefab, tiles[(int)playerPos.x, (int)playerPos.y].transform.position, Quaternion.identity);
        player.transform.position = new Vector3(player.transform.position.x, 0.88f, player.transform.position.z);
        GameObject.Find("Main Camera").GetComponent<CameraManager>().SetPlayer(player.transform);
    }
}
