using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float _smooth = 5f;
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _axis = new(0, 0, 10f);
    private Transform _host;

    public void SetHost(Transform host)
    {
        _host = host;
    }

    private void LateUpdate()
    {
        _transform.position = Vector3.Lerp(_transform.position, _host.position + _axis, _smooth * Time.deltaTime);
    }
}