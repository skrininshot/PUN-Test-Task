using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI Singleton;
    [field: SerializeField] public Joystick LeftJoystick { get; private set; }
    [field: SerializeField] public Joystick RightJoystick { get; private set; }

    private void Awake()
    {
        if (Singleton)
        {
            Destroy(gameObject);

            return;
        }

        Singleton = this;
    }

}
