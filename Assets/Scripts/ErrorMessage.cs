using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ErrorMessage : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Start()
    {
        _text.text = "";
    }

    public void ShowMessage(string text, float time)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageAnimation(text, time));
    }

    private IEnumerator ShowMessageAnimation(string text, float time)
    {
        _text.text = text;
        yield return new WaitForSeconds(time);
        _text.text = "";
    }
}
