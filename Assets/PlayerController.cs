using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public float speed = 5;
	private Vector2 movementInput = Vector2.zero;

	public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

	private void Update()
	{
		transform.Translate(new Vector3(movementInput.x, movementInput.y) * speed * Time.deltaTime);
	}
}
