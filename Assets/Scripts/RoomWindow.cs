using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomWindow : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _roomNameText;
    [SerializeField] private Transform _playerList;
    [SerializeField] private PlayerRoomItem _playerItemPrefab;

    public override void OnEnable()
    {
        _roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        foreach (Player player in PhotonNetwork.PlayerList)
            Instantiate(_playerItemPrefab, _playerList).SetPlayer(player);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(_playerItemPrefab, _playerList).SetPlayer(newPlayer);
    }

    public void StartGame()
    {

    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        gameObject.SetActive(false);
    }
}