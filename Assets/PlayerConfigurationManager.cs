using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
  private List<PlayerConfiguration> _players;

  [SerializeField]
  private int MaxPlayers = 2;

  public static PlayerConfigurationManager Instance { get; private set; }

	public void Awake()
	{
		if(Instance != null)
    {
      Logger.LogMessage("Trying to create new instance of singleton");
    }
    else
    {
      Instance = this;
      DontDestroyOnLoad(Instance);
      _players = new List<PlayerConfiguration>();
    }
	}

  public void HandlePlayerJoin(PlayerInput input)
  {
    if (!_players.Any(item => item.PlayerIndex == input.playerIndex))
    {
			Logger.LogMessage("Player joined: " + input.playerIndex);
			input.transform.SetParent(transform);
      _players.Add(new PlayerConfiguration(input));
    }
    else
    {
      Logger.LogMessage("Player already joined");
    }
  }

  public void ReadyPlayer(int index)
  {
    _players[index].IsReady = true;
    if (_players.Count == MaxPlayers && _players.All(item => item.IsReady))
    {
      SceneManager.LoadScene("NextScene");
    }
  }

	public List<PlayerConfiguration> GetPlayerConfigs()
	{
		return _players;
	}
}

public class PlayerConfiguration
{
  public PlayerConfiguration(PlayerInput input)
  {
    Input = input;
  }

  public PlayerInput Input { get; set; }
  public int PlayerIndex => Input.playerIndex;
  public bool IsReady { get; set; }
}
