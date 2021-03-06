﻿using UnityEngine;

public class HeroAnimator : MonoBehaviour
{

    private Animator _myAnimController;
    private Rigidbody2D _myRG;
    private MovementController _mcHero;

    // Start is called before the first frame update
    void Start()
    {
        _myAnimController = GetComponent<Animator>();
        _myRG = GetComponent<Rigidbody2D>();
        _mcHero = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        _myAnimController.SetFloat("Movespeed", Mathf.Abs(_myRG.velocity.x));
        if (Input.GetButtonDown("Jump") && _mcHero.isOnGround)
        {
            _myAnimController.SetTrigger("Jump");
        }
        _myAnimController.SetBool("IsOnGround", _mcHero.isOnGround);
    }
}
