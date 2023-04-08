using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class RoomWindow : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _roomNameText;
    [SerializeField] private Transform _playerList;
    [SerializeField] private PlayerRoomItem _playerItemPrefab;
    [SerializeField] private Button _startGame;

    public override void OnEnable()
    {
        base.OnEnable();
        _roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        _startGame.gameObject.SetActive(PhotonNetwork.IsMasterClient);

        foreach (Player player in PhotonNetwork.PlayerList)
            Instantiate(_playerItemPrefab, _playerList).SetPlayer(player);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _startGame.gameObject.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(_playerItemPrefab, _playerList).SetPlayer(newPlayer);
    }

    public override void OnLeftRoom()
    {
        gameObject.SetActive(false);
    }
}