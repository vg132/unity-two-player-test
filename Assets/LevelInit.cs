using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
	[SerializeField]
	private Transform[] PlayerSpawns;

	[SerializeField]
	private GameObject playerPrefab;

	void Start()
	{
		var playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs();
		for (int i = 0; i < playerConfigs.Count; i++)
		{
			var player = Instantiate(playerPrefab,  PlayerSpawns[i].position, PlayerSpawns[i].rotation, gameObject.transform);
			player.GetComponent<PlayerController>().InitializePlayer(playerConfigs[i]);
		}

	}
}
