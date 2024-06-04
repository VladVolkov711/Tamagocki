using UnityEngine;
using TMPro;

public class TextUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _subTitleText;

    private void FixedUpdate() => _subTitleText.text = _titleText.text;
}
