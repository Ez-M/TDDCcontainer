using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    public Tilemap backgroundMap;
    public Tilemap gameTilesMap;

    public Dictionary<int, Entity> allEntities;

    public Dictionary<Vector3, List<Entity>> tilecontents;

    private static GridManager Instance;
    public static GridManager instance {get{return Instance;}}

    void awake()
    {
        verifyInstanceSingleton();


    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 cellCenterFromWorld(Vector3 worldPos)
    {
        var CellGridPos = backgroundMap.WorldToCell(worldPos);
        return backgroundMap.GetCellCenterWorld(CellGridPos);
    }

    private void verifyInstanceSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        } else
        {
            Instance = this;
        }
    }


    
}


