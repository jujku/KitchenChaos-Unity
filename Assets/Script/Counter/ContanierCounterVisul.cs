using UnityEngine;

public class ContanierCounterVisul : MonoBehaviour
{

    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    public void PlayOpen()
    {
        anim.SetTrigger("OpenClose");
    }
    void Update()
    {
        
    }
}
