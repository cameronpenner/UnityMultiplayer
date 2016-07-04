using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkComponentController : NetworkBehaviour
{
	[SerializeField]
	[Tooltip("Components that should only be active for the local client")]
	private Behaviour[] _clientBehaviours;

	[SerializeField]
	[Tooltip("Gameobjects that should only be active for the local client")]
	private GameObject[] _clientGameObjects;

	private void Start()
	{
		//activate the NetworkAnimator so it syncs for all players
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);

		//disable components that should only be active for the local client
		if(!isLocalPlayer)
		{
			foreach(var behaviour in _clientBehaviours)
			{
				behaviour.enabled = false;
			}

			foreach(var gameObject in _clientGameObjects)
			{
				gameObject.SetActive(false);
			}
		}
	}
}
