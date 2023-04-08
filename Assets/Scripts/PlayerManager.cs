using UnityEngine;
using Photon.Pun;
using System.IO;

[RequireComponent(typeof(PhotonView))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;

    private void Start()
    {
        if (_photonView.IsMine)
            CreatePlayerController();
    }

    private void CreatePlayerController()
    {
        string fileName = Path.Combine("PhotonPrefs", "PlayerController");
        PhotonNetwork.Instantiate(fileName, Vector3.zero, Quaternion.identity);
    }
}
