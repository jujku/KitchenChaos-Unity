using System;
using UnityEngine;

public class PlayerAnima : MonoBehaviour

{
    private Animator anim;
    
    private String IS_WALK = "isWalk";

    [SerializeField]private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_WALK,player.IsWalk);
    }
}
