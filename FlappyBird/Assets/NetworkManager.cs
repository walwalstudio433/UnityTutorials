using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;
using UnityEditor;
using System.Runtime.Serialization;

public class NetworkManager : MonoBehaviour {
	public SocketIOComponent socket;

	private static Queue<System.Action> eventQueue = new Queue<System.Action> ();
	private static NetworkManager networkManager;
	public static NetworkManager instance {
		get {
			if (!networkManager) {
				networkManager = FindObjectOfType (typeof(NetworkManager)) as NetworkManager;
				if (!networkManager) {
					Debug.LogError ("There needs to be one active NetworkManager on your scene.");
				}
			}

			return networkManager;
		}
	}

	public static void On(string eventName, System.Action<JSONObject> callback) {
		instance.socket.On (eventName, delegate(SocketIOEvent obj) {
			lock(eventQueue) {
				eventQueue.Enqueue(delegate() {
					callback(obj.data);
				});
			}
		});
	}

	public static void Emit(string eventName, JSONObject data) {
		instance.socket.Emit (eventName, data);
	}

	void Start() {
	}

	void Update() {
		while (eventQueue.Count > 0) {
			System.Action callback;
			lock (eventQueue) {
				callback = eventQueue.Dequeue ();
			}
			callback ();
		}
	}
}

public class NetworkManagerUtils {
	public static JSONObject ToJSON(object obj) {
		return new JSONObject(JsonUtility.ToJson(obj));
	}
}
