using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed = 5;
	private Vector2 movementInput = Vector2.zero;
	private PlayerController2 _controls;
	private PlayerConfiguration _playerConfig;

	private void Awake()
	{
		_controls = new PlayerController2();
	}

	public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();

	public void OnAction(InputAction.CallbackContext ctx)
	{
		Debug.Log("Action! Load next scene");
		SceneManager.LoadScene("NextScene");
	}

	private void Update()
	{
		transform.Translate(new Vector3(movementInput.x, movementInput.y) * speed * Time.deltaTime);
	}

	public void InitializePlayer(PlayerConfiguration config)
	{
		Debug.Log("Init Player");
		_playerConfig = config;
		//playerMesh.material = config.playerMaterial;
		config.Input.onActionTriggered += Input_onActionTriggered;
	}

	private void Input_onActionTriggered(InputAction.CallbackContext ctx)
	{
		Debug.Log("Input action");
		if (ctx.action.name == _controls.PlayerControlls.Move.name)
		{
			OnMove(ctx);
		}
	}
}
