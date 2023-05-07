using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    public Player Player { get => player;}

    private Inputs inputs;
    public Inputs Inputs {get => inputs;}


    void Awake()
    {
        inputs = new Inputs();
        inputs.Enable();
        inputs.Movement.North.performed += NorthFunc;
        inputs.Movement.South.performed += SouthFunc;
        inputs.Movement.West.performed += WestFunc;
        inputs.Movement.East.performed += EastFunc;
    }

    #region -InputFuncs-

        #region -MovementInputs-
    public void NorthFunc(InputAction.CallbackContext ctx)
    {
    if(ctx.performed)
    {
    Debug.Log ("North input called.");
    GridManager.instance.MoveEntityByDirection(new Vector3(0, 1, 0), Player.GetComponent<Entity>());
    }

    }
    public void SouthFunc(InputAction.CallbackContext ctx)
    {

        Debug.Log ("South input Added.");
    }
    public void WestFunc(InputAction.CallbackContext ctx)
    {

        Debug.Log ("West input Added.");
    }
    public void EastFunc(InputAction.CallbackContext ctx)
    {

        Debug.Log ("East input Added.");
    }
        #endregion

        
    #endregion
}
