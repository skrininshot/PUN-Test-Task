using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LoadingTextAnimation : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private string _content = "Loading";
    [SerializeField] private float _speed = 0.1f;

    private int _dotCount = 0;

    private void OnEnable()
    {
        StartCoroutine(TextAnimation());
    }

    private void OnDisable()
    {
        StopCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        WaitForSeconds wait = new (_speed);

        while (true)
        {
            _text.text = _content + new string('.', _dotCount);
            _dotCount++;

            if (_dotCount > 3)
                _dotCount = 0;

            yield return wait;
        }
    }
}