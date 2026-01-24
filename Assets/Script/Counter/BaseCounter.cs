using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    [SerializeField] private GameObject seceltedCounter;
    public virtual void Interact(Player player)
    {
     
    }
    
    public void SeletedCounter()
    {
        seceltedCounter.SetActive(true);
    }
    public void CancelSelected()
    {
        seceltedCounter.SetActive(false);
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
