using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Nornal , 
    pickUp,
}
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform cameraTransform;

    [Header("이동 설정")]
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("바닥 설정")]
    [SerializeField] private float gravity = -20f;

    private CharacterController controller;
    private float verticalVelocity;
    private PlayerState curentState = PlayerState.Nornal;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            return;
        }

        ApplyGravity();
        if (curentState != PlayerState.Nornal) return;

        HandleMovement(keyboard);
    }
    private void HandleMovement(Keyboard keyboard)
    {
        Vector2 input = Vector2.zero;

        if (keyboard.aKey.isPressed)
            input.x -= 1f;
        if (keyboard.dKey.isPressed)
            input.x += 1f;
        if (keyboard.sKey.isPressed)
            input.y -= 1f;
        if (keyboard.wKey.isPressed)
            input.y += 1f;
        input = Vector2.ClampMagnitude(input, 1f);
    }
    private void ApplyGravity()
    {
        if (controller.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity -= -2f;
        }
        else
        {
            verticalVelocity = -2f;
        }
        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }
    
}
