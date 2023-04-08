using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

[RequireComponent(typeof(PhotonView))]
public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Singleton;

    private void Awake()
    {
        if (Singleton)
        {
            Destroy(gameObject);

            return;
        }

        Singleton = this;
        DontDestroyOnLoad(gameObject);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name != "Game") return;

        string prefabName = Path.Combine("PhotonPrefs", "PlayerManager");
        PhotonNetwork.Instantiate(prefabName, Vector3.zero, Quaternion.identity);
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}