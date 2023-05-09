using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Movement
{
    private static GridManager gridManager = GridManager.Instance;

    public static void MoveEntityByDirection(Vector3 moveDirection, Entity _entity)
    {   // North = y1, South = y-1, West = x-1, East = x1 //

        Vector3 targetPosition = _entity.transform.position + moveDirection;

        if (gridManager.CheckTileBlocksMovement(targetPosition, out var blocker))
        {
            _entity.Bump(blocker);
        }
        else
        {
            gridManager.ClearEntityLocation(_entity.transform.position, _entity);
            _entity.transform.position = targetPosition;
            gridManager.RegisterLocation(targetPosition, _entity);

        }


    }


}