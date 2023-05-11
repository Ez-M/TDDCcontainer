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

    private static GridManager instance;
    public static GridManager Instance { get { return instance; } }

    void Awake()
    {
        verifyInstanceSingleton();

    }

        private void OnDisable()
    {
        if(instance == this)
        {
            instance = null;
        }
    }


    public Vector3 cellCenterFromWorld(Vector3 worldPos)
    {
        var CellGridPos = backgroundMap.WorldToCell(worldPos);
        return backgroundMap.GetCellCenterWorld(CellGridPos);
    }

    private void verifyInstanceSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }



    public void RegisterLocation(Vector3 EntityPos, Entity _entity)
    {

        var cellCenterPos = cellCenterFromWorld(EntityPos);
        if (tilecontents.ContainsKey(cellCenterPos))
        {
            tilecontents[cellCenterPos].contents.Add(_entity);
        }
        else
        {
            var tileContainer = new TileContainer();
            tileContainer.contents.Add(_entity);
            tilecontents.Add(cellCenterPos, tileContainer);

        }
    }

    public void ClearEntityLocation(Vector3 _entityPos, Entity _entity)
    {
        var cellCenterPos = cellCenterFromWorld(_entityPos);
        if(tilecontents[cellCenterPos].contents.Contains(_entity))
        {
            tilecontents[cellCenterPos].contents.Remove(_entity);
        }
        if(tilecontents[cellCenterPos].contents.Count < 1)
        {tilecontents.Remove(cellCenterPos);}
    }


    public bool CheckTileBlocksMovement(Vector3 targetPosition, out Entity blocker)
    {//honestly needs to check if the tile is within the map boundaries but I haven't set that yet
        if (tilecontents.TryGetValue(targetPosition, out TileContainer _tileContainer))
        {
            foreach (var item in _tileContainer.contents)
            {
                if (item.BlocksMovement == true)
                {
                    blocker = item;

                    return true;
                }
            }
            blocker = null;

            return false;
        }
        else
        {
            blocker = null;

            return false;
        }
    }

    public ItemData GetFirstItemInCell(Vector3 _worldPos)
    {
        var targetTile = cellCenterFromWorld(_worldPos);
        var tileContents = 
        tilecontents[targetTile].contents;
        foreach (var entity in tileContents)
        {
            if(entity is GroundItem groundItem && groundItem.isPickable)
            {
                return groundItem.itemData;
            }
        }
        return null;
    }


}

[Serializable]
public class TileContainer
{
    [SerializeReference]
    public List<Entity> contents = new List<Entity>();
    // public bool blocksMovement = false;
}



#region SeralizedDicts
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

#endregion