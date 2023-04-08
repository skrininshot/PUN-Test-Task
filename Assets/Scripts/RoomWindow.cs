using UnityEngine;
using UnityEngine.UI;

public class RoomWindow : MonoBehaviour
{
    [SerializeField] private Text _roomNameText;

    public void SetRoomName(string name)
    {
        _roomNameText.text = name;
    }
}