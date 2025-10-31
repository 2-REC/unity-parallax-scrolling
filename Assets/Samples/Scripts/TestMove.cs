/* Simple script to make an object move constantly along a direction on XY plane. */

using UnityEngine;
using UnityEngine.InputSystem;

public class TestMove : MonoBehaviour {

    public InputActionAsset inputActions;
    public float moveSpeed = .1f;

    InputAction moveAction;
    Vector2 moveAmount;


    private void OnEnable() {
        inputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable() {
        inputActions.FindActionMap("Player").Disable();
    }

    private void Awake() {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update() {
        moveAmount = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate() {

        transform.position += new Vector3(moveAmount.x * moveSpeed, moveAmount.y * moveSpeed, 0f);
    }

}
