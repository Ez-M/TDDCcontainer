using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Movement
{
    private static GridManager gridManager = GridManager.instance;

    public static void MoveEntityByDirection(Vector3 moveDirection, Entity _entity)
    {   // North = y1, South = y-1, West = x-1, East = x1 //

        Vector3 targetPosition = _entity.transform.position + moveDirection;

        if(!gridManager.CheckTileBlocksMovement(targetPosition))
        {
            _entity.transform.position = targetPosition;     

        }   else {Debug.Log("Tile Blocks Movement");}


    }


}