using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonoSingleton<T> : MonoBehaviour where T : Component {
	private static T instance = null;
	private static bool isExiting = false;

	public static T Instance {
		get {
			if(instance == null && !isExiting) {
				GameObject newManager = new GameObject(string.Empty);
				instance = newManager.AddComponent<T>();
				instance.name = "_Singleton" + instance.GetComponent<T>().ToString();
			}
			return instance;
		}
	}

	#region MonoBehaviour
	public virtual void Awake() {
		VerifySingleton();
		DontDestroyOnLoad(gameObject);
	}

	void OnApplicationQuit() {
		isExiting = true;
	}
	#endregion

	protected void VerifySingleton() {
		List<T> instanceList = new List<T>(FindObjectsOfType<T>());

		if(instance == null) {
			// Not sure which instance should be the singleton.
			if(instanceList.Count > 1) {
				Debug.LogError("Multiple instances of a singleton exists.", this);
				Debug.Break();
			}

			// If this is the only instance
			if(instanceList.Count == 1) {
				instance = this as T;
			}
		} else {
			// There is already an instance. Destroy this GameObject to ensure there are no duplicates
			Destroy(gameObject);
		}
	}

	public void UnloadSingleton(bool objToRemove) {
		string unloadMessage = (objToRemove)
			? name + " reference was unloaded."
			: name + " reference was unloaded and destroyed.";
		Debug.Log(unloadMessage);
		instance = null;
		if(objToRemove) {
			Destroy(gameObject);
		}
	}
}