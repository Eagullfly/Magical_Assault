using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    [SerializeField]
    private string Level;

    [SerializeField]
    private Transform map;

    private Point mapSize;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject wayPoint;

    private int xAxis, yAxis;

    public GameObject SpawnPit { get; set; }

    public Dictionary<Point, TileScript> Tiles { get; set; }

    public float TileSize
    {
       get { return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

        mapSize = new Point(mapData[0].ToCharArray().Length, mapData.Length);

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;
        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));
        for(int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();
            for(int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(), x, y, worldStart);

            }
        }
        SpawningPit();
    }

    private void PlaceTile(string tileType, int x, int y, Vector3 worldStart)
    {
        //Debug.Log(tileType);
        if(tileType == "4")
        {
            xAxis = x;
            yAxis = y;
            //Debug.Log(x + " " + y);
        }
        int tileIndex = int.Parse(tileType);
        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();
        newTile.Setup(new Point(x, y), new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y), 0), map);
        
        
    }

    private void SpawningPit()
    {
        
        Point spawnPointIndex = new Point(xAxis, yAxis);
        GameObject tmp = (GameObject) Instantiate(spawnPoint, Tiles[spawnPointIndex].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
        SpawnPit = tmp;
        SpawnPit.name = "SpawningPoint";


    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load(Level) as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }

    public bool InBounds(Point position)
    {
        return position.X >= 0 && position.Y >= 0 && position.X < mapSize.X && position.Y < mapSize.Y;
    }
}
