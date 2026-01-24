using UnityEngine;

public class ContanierCounter : BaseCounter
{
    [SerializeField] private kitchenObjectSO kitchenObjectSO;
    [SerializeField] private ContanierCounterVisul visul;


    void Awake()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            // 2. 修改 Sprite
            sr.sprite = kitchenObjectSO.sprite;
        }
        else
        {
            Debug.LogError("未在子物体上找到 SpriteRenderer！");
        }
    }
    public override void Interact(Player player)
    {
        base.Interact(player);
        Debug.Log(gameObject + "交互的对象是" + GetComponent<KitchenObject>());
        if(player.GetKitchenObject() == null){

            visul.PlayOpen();

        KitchenObject kitchenObject = GameObject.Instantiate(kitchenObjectSO.prefab,GetHoldPoint()).GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
        TransforKitchenObject(this,Player.Instance);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
