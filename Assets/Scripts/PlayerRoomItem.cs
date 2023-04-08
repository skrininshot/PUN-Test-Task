using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(Text))]
public class PlayerRoomItem : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _playerRoomText;
    private Player _player;

    public void SetPlayer(Player player)
    {
        _player = player;
        _playerRoomText.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (_player == otherPlayer)
            Destroy(gameObject);
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
