using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    private KitchenObject kitchenObject;
    [SerializeField] private Transform holdPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        Debug.Log(gameObject + "已经设置" + kitchenObject);
        this.kitchenObject = kitchenObject;
        if(kitchenObject != null){
        kitchenObject.transform.localPosition = Vector3.zero;
        }
    }

    public Transform GetHoldPoint()
    {
        return holdPoint;        
    }

    public void TransforKitchenObject(KitchenObjectHolder sourceHolder,KitchenObjectHolder targetHolder)
    {
        Debug.Log(gameObject + "进行转换" + sourceHolder +"  " + targetHolder);
        if (sourceHolder.GetKitchenObject() == null)
        {
            Debug.Log("源持有者不存在食材");
            return;
        }
        if(targetHolder.GetKitchenObject() != null)
        {
            Debug.Log("目标持有者已存在食材");
            return;
        }
        Debug.Log(gameObject + "进行转换");
        targetHolder.AddKitchnObject(sourceHolder.GetKitchenObject());
        sourceHolder.ClearKitchenObject();


    }
    public void AddKitchnObject(KitchenObject kitchenObject)
    {
        kitchenObject.transform.SetParent(holdPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
    public void ClearKitchenObject()
    {
        SetKitchenObject(null);
    }
}
