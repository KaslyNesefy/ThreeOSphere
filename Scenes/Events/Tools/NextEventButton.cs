using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NextEventButton : MonoBehaviour
{
    private Event _nextEvent;

    private void Awake() => GetComponent<Button>().onClick.AddListener(OnClick);
    private void OnClick() => EventMachine.SetNewEvent(_nextEvent);
    public void SetButton(string buttonText, Event nextEvent)
    {
        GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        _nextEvent = nextEvent;
    }
}
