using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public TowerButton ClickedButton { get; set; }

    public Transform projectile01;
    
    private int currency;

    [SerializeField]
    private Text currencyText;

    public ObjectPool Pool { get; set; }

    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
            this.currency = value;
            this.currencyText.text = "<color=lime>$</color>" + value.ToString();
        }
    }

    private void Awake()
    {
        Pool = GetComponent<ObjectPool>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Currency = 200;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEscape();
    }

    public void PickTower(TowerButton towerButton)
    {
        if (Currency >= towerButton.Price)
        {
            this.ClickedButton = towerButton;
            Hover.Instance.Activate(towerButton.Sprite);
        }
        
    }

    public void BuyTower()
    {
        if (Currency >= ClickedButton.Price)
        {
            Currency -= ClickedButton.Price;
            Hover.Instance.Deactivate();
        }
        
    }

    private void HandleEscape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.Deactivate();
        }
    }

    /*public void StartWave()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        int enemyIndex = Random.Range(0, 2);

        string type = string.Empty;

        switch (enemyIndex)
        {
            case 0:
                type = "Orc";
                break;
            case 1:
                type = "ArmoredOrc";
                break;
        }

        Enemy enemy = Pool.GetObject(type).GetComponent<Enemy>();
        enemy.Spawn();
        yield return new WaitForSeconds(2.5f);
    }*/
}
