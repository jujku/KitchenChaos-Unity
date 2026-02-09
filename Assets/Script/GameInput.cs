using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{

    [SerializeField] private GameContorlle gameControlle;
    public event EventHandler OnInteractAction;
    public event EventHandler OnOpreateAction;
    void Awake()
    {
        gameControlle = new GameContorlle();
        gameControlle.Player.Enable();
        gameControlle.Player.Interact.performed += Interact_Performed;
        gameControlle.Player.Opreate.performed += Opreate_Performed;
    }

    private void Interact_Performed(InputAction.CallbackContext context)
    {
       OnInteractAction?.Invoke(this,EventArgs.Empty);
    }

    private void Opreate_Performed(InputAction.CallbackContext context)
    {
        OnOpreateAction?.Invoke(this,EventArgs.Empty);
    }

    public Vector3 GetMOvementDirectionNormalized()
    {
        
       Vector2 inputVector2 = gameControlle.Player.Move.ReadValue<Vector2>();


        Vector3 direction = new Vector3(inputVector2.x,0,inputVector2.y);
        return direction;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
