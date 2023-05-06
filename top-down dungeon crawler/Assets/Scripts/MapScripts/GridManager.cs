using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    public Tilemap backgroundMap;
    public Tilemap gameTilesMap;

    // public Dictionary<int, Entity> allEntities;

    // [SerializeField]
    // public Dictionary<Vector3, TileContainer> tilecontents;

    public IntEntityDictionary allEntities = new IntEntityDictionary();

    public Vector3TileContainerDictionary tilecontents = new Vector3TileContainerDictionary();

    private static GridManager Instance;
    public static GridManager instance {get{return Instance;}}

    void Awake()
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
            Destroy(this.gameObject);
        } else
        {
            Instance = this;
        }
    }

    internal void RegisterLocation(Vector3 EntityPos, Entity _entity)
 {
    
       var cellCenterpos = cellCenterFromWorld(_entity.transform.position);
       if(tilecontents.ContainsKey(cellCenterpos))
        {
            tilecontents[cellCenterpos].contents.Add(_entity);
        } else
            {
                var tileContainer = new TileContainer();
                tileContainer.contents.Add(_entity);
                tilecontents.Add(cellCenterpos, tileContainer);

            }
    }


    public void MoveEntityByDirection(Vector3 moveDirection, Entity _entity)
    {   // N y1, S y-1, W x-1, E x1
    
        if(tilecontents.ContainsKey(_entity.transform.position + moveDirection))
        {
            if(tilecontents[_entity.transform.position + moveDirection].blocksMovement == false)
            {
                _entity.gameObject.transform.position += moveDirection;
            }
        }
        // if(CheckObstacles)
        // 
    }
}

[Serializable]
public class TileContainer
{
    public List<Entity> contents = new List<Entity>();
    public bool blocksMovement = false;
}




public abstract class UnitySerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
	[SerializeField]
	private List<TKey> keyData = new List<TKey>();
	
	[SerializeField]
	private List<TValue> valueData = new List<TValue>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
		this.Clear();
		for (int i = 0; i < this.keyData.Count && i < this.valueData.Count; i++)
		{
			this[this.keyData[i]] = this.valueData[i];
		}
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
		this.keyData.Clear();
		this.valueData.Clear();

		foreach (var item in this)
		{
			this.keyData.Add(item.Key);
			this.valueData.Add(item.Value);
		}
    }
}
[Serializable]
public class KeyCodeGameObjectListDictionary : UnitySerializedDictionary<KeyCode, List<GameObject>> { }

[Serializable]
public class StringScriptableObjectDictionary : UnitySerializedDictionary<string, ScriptableObject> { }

[Serializable]
public class Vector3TileContainerDictionary : UnitySerializedDictionary<Vector3, TileContainer> { }
[Serializable]
public class IntEntityDictionary : UnitySerializedDictionary<int, Entity> { }