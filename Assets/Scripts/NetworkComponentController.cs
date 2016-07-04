using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkComponentController : NetworkBehaviour
{
	[SerializeField]
	private Behaviour[] _clientBehaviours;

	[SerializeField]
	private GameObject[] _clientGameObjects;

	private void Start()
	{
		GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);

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
