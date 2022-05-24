using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    #region Attributes

    private PlayerMovement _playerMovement;
    private Animator _animator;

    #endregion

    #region Start-Update

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("_isWalking",_playerMovement._isWalking);
    }

    #endregion
}