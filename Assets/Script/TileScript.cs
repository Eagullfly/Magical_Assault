using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }

    public Vector2 WorldPosition { 
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y/2));
        }
    }

    public bool IsEmpty{ get; private set; }

    private Color32 fullColor = new Color32(174, 56, 17, 255);

    private Color32 emptyColor = new Color32(42, 190, 58, 255);

    public SpriteRenderer SpriteRenderer { get; set; }

    public bool Walkable { get; set; }

    public bool Debugging { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        Walkable = true;
        IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {
        
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedButton != null)
        {
            if (IsEmpty && !Debugging)
            {
                ColorTile(emptyColor);
            }
            if ((!IsEmpty || name != "GrassSpawnPoint(Clone)") && !Debugging)
            {
                ColorTile(fullColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }
        
    }

    private void OnMouseExit()
    {
        if (!Debugging)
        {
            ColorTile(Color.white);
        }
        
    }

    private void PlaceTower()
    {
        
        if(name == "GrassSpawnPoint(Clone)"){
            GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickedButton.TowerPrefab, transform.position, Quaternion.identity);
            tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

            tower.transform.SetParent(transform);

            IsEmpty = false;

            ColorTile(Color.white);

            GameManager.Instance.BuyTower();

            Walkable = false;
        }
        
    }

    private void ColorTile(Color newColor)
    {
        SpriteRenderer.color = newColor;
    }
}
