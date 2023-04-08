using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Lobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _createRoomText;
    [SerializeField] private InputField _joinRoomText;
    [SerializeField] private ErrorMessage _errorText;
    [SerializeField] private LoadingTextAnimation _loadingTextAnimation;
    [SerializeField] private RoomWindow _room;

    private void Start()
    {
        PhotonNetwork.NickName = "Player-" + Math.GetRandomDigits(5);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(_createRoomText.text)) return;

        PhotonNetwork.CreateRoom(_createRoomText.text);
        _loadingTextAnimation.gameObject.SetActive(true);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        _loadingTextAnimation.gameObject.SetActive(false);
        _errorText.ShowMessage("Something went wrong!", 5f);
    }

    public void JoinRoom()
    {
        if (string.IsNullOrEmpty(_joinRoomText.text)) return;

        PhotonNetwork.JoinRoom(_joinRoomText.text);
        _loadingTextAnimation.gameObject.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        _room.gameObject.SetActive(true);
        _loadingTextAnimation.gameObject.SetActive(false);
    }
}
