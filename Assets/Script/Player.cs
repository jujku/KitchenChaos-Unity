using System;
using UnityEngine;

public class Player : KitchenObjectHolder
{
    public static Player Instance {get;private set;}
    [SerializeField]private float moveSpeed = 7.0f;
    [SerializeField]private  float rotateSpeed = 10.0f;
    [SerializeField]private GameInput gameInput;
    [SerializeField]private LayerMask counterLayerMasl;
    private BaseCounter selectedCounter;
    private bool isWalk = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() 
{
    // 如果 Instance 已经存在且不是自己，说明场景中有多个 Player，需处理
    if (Instance != null && Instance != this) 
    {
        Destroy(gameObject);
        return;
    }
    // 关键：在这里给 Instance 赋值
    Instance = this; 
}
    void Start()
    {
        gameInput.OnInteractAction += GameInput_OnInteractAction;
    }

    void Update()
    {
        HandleInteract();
    }
    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
        // HandleInteract();
        Debug.Log(gameObject + "GameInput_OnInteractAction 已经执行");
        selectedCounter?.Interact(this);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        // float horizontal = Input.GetAxisRaw("Horizontal");
        // float vertical = Input.GetAxisRaw("Vertical");

        // Vector3 direction = new Vector3(horizontal,0,vertical);
        HandleMove();
      
    }
    private void HandleMove()
    {
           Vector3 direction = gameInput.GetMOvementDirectionNormalized();
        
        isWalk = direction != Vector3.zero;

        transform.position += direction * Time.deltaTime * moveSpeed;

        if(direction != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward,direction,rotateSpeed * Time.deltaTime);
        }
    }
    private void HandleInteract()
    {
        RaycastHit hitinfo;
        bool isCollide = Physics.Raycast(transform.position,transform.forward,out hitinfo,2f,counterLayerMasl);
        if (isCollide)
        {
            if(hitinfo.transform.TryGetComponent<BaseCounter>(out BaseCounter counter))
            {

                SetSelectedCounter(counter);

            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }
    public void SetSelectedCounter(BaseCounter counter)
    {
        if(counter != selectedCounter)
        {
            selectedCounter?.CancelSelected();
            counter?.SeletedCounter();
            this.selectedCounter = counter;
        }
    }
    public bool IsWalk
    {
        get
        {
            return isWalk;
        }     
    }
}
