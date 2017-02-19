using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonoSingleton<T> : MonoBehaviour where T : Component {
    //Taken from a group project. Put in project by Michael Harp, probably written by him too.
    //MonoSingletons are kinda generic both the idea and excecution, not sure if credit is necessary
    private static T instance = null;
    private static bool isExiting = false;

    public static T Instance {
        get {
            if (instance == null && !isExiting) {
                instance = FindObjectOfType<T>();
                if (instance == null) {
                    GameObject newManager = new GameObject(string.Empty);
                    instance = newManager.AddComponent<T>();
                    instance.name = instance.GetComponent<T>().ToString() + " (Singleton)";
                }
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

        // Ensure there are no duplicates
        if (instance != null) {
            Destroy(gameObject);
        }

        // Not sure which instance should be the singleton.
        if (instanceList.Count > 1 && instance == null) {
            Debug.LogError("Multiple instances of a singleton exists, not sure which to set reference.", this);
            Debug.Break();
        }

        // If this is the only instance
        if (instanceList.Count == 1 && instance == null) {
            instance = this as T;
        }
    }

    public void UnloadSingleton(bool objToRemove) {
        string unloadMessage = (objToRemove)
            ? name + " reference was unloaded."
            : name + " reference was unloaded and destroyed.";
        Debug.Log(unloadMessage);
        instance = null;
        if (objToRemove) {
            Destroy(gameObject);
        }
    }
}