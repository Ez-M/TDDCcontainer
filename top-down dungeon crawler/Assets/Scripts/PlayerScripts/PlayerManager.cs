using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Player player;
    public Player Player { get => player;}

    private InventoryObject inventoryObject;
    public InventoryObject InventoryObject {get => inventoryObject;}

    private PlayerInventoryHandler playerInventoryHandler;
    private PlayerInventoryHandler PlayerInventoryHandler {get => playerInventoryHandler;}

    public InventoryUI inventoryUI;

    private Inputs inputs;
    public Inputs Inputs {get => inputs;}

    private GridManager gridManager;


    void Awake()
    {
        gridManager = GridManager.Instance;
        playerInventoryHandler = gameObject.GetComponent<PlayerInventoryHandler>();
        inventoryObject = playerInventoryHandler.inventory;

        inputs = new Inputs();
        inputs.Enable();
        inputs.Movement.North.performed += NorthFunc;
        inputs.Movement.South.performed += SouthFunc;
        inputs.Movement.West.performed += WestFunc;
        inputs.Movement.East.performed += EastFunc;
        inputs.Interactions.GrabItem.performed += GrabItem;
        inputs.Inventory.ToggleInventory.performed += ToggleInventory;

        
    }

    void OnEnable()
    {
        player.SetInventoryObject(inventoryObject);
        inventoryUI.InitInventoryUI();
    }

        private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            inventoryObject.Save();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            inventoryObject.Load();
        }
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

        public void GrabItem(InputAction.CallbackContext ctx)
        {
            var itemToGrab = gridManager.GetFirstItemInCell(player.transform.position);

            if(player.InventoryObject.inventory.CheckSpaceTemp())
            {
                foreach(var slot in player.InventoryObject.inventory.Slots)
                {

                    if(slot.item.ItemCode < 0)
                    {
                        slot.UpdateSlot(1, itemToGrab, 1);
                        inventoryUI.UpdateUI();
                        return;
                    }
                }
            }
        }

        public void ToggleInventory(InputAction.CallbackContext ctx)
        {
            inventoryUI.toggleUI();
        }

    #endregion
}
