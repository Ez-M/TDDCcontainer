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
        Movement.MoveEntityByDirection(new Vector3(0, 1, 0), Player);
    }

    }
    public void SouthFunc(InputAction.CallbackContext ctx)
    {

        Debug.Log ("South input Added.");
        Movement.MoveEntityByDirection(new Vector3(0, -1, 0), Player);

    }
    public void WestFunc(InputAction.CallbackContext ctx)
    {

        Debug.Log ("West input Added.");
        Movement.MoveEntityByDirection(new Vector3(-1, 0, 0), Player);

    }
    public void EastFunc(InputAction.CallbackContext ctx)
    {

        Debug.Log ("East input Added.");
        Movement.MoveEntityByDirection(new Vector3(1, 0, 0), Player);

    }
        #endregion

        
    #endregion
}
