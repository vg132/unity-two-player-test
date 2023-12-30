using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPlayerReady : MonoBehaviour
{
	private PlayerInput _playerInput;

	private void Awake()
	{
		Logger.LogMessage($"Menu Player Ready Awake.");
	}

	private void Start()
	{
		_playerInput = GetComponent<PlayerInput>();
		Logger.LogMessage(_playerInput.GetType().Name);
		_playerInput.onActionTriggered += _playerInput_onActionTriggered;
	}

	private void OnEnable()
	{
		Logger.LogMessage("Enable "+Guid.NewGuid());
	}

	private void OnDisable()
	{
		Logger.LogMessage("Disable" + Guid.NewGuid());
	}

	private void _playerInput_onActionTriggered(InputAction.CallbackContext obj)
	{
		if (SceneManager.GetActiveScene().name == "NextScene")
		{
			return;
		}
		_playerInput = GetComponent<PlayerInput>();
		Logger.LogMessage($"Player Ready! Index: {_playerInput.playerIndex}");
		PlayerConfigurationManager.Instance.ReadyPlayer(_playerInput.playerIndex);
	}
}
