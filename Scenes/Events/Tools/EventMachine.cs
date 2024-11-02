using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventMachine : MonoBehaviour
{
    private static StateMachine _stateMachine = new StateMachine();

    [SerializeField] private TextMeshProUGUI namePlace;
    [SerializeField] private TextMeshProUGUI descriptionPlace;
    [SerializeField] private Canvas buttonsPlace;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Image imagePlace;
    private protected EventPattern eventPattern;

    private void Awake()
    {
        eventPattern.NamePlace = namePlace;
        eventPattern.DescriptionPlace = descriptionPlace;
        eventPattern.ButtonsPlace = buttonsPlace;
        eventPattern.ButtonPrefab = buttonPrefab;
        eventPattern.ImagePlace = imagePlace;
        _stateMachine.Initialize(new Event_Initialize(eventPattern));//_stateMachine.Initialize(new Event(namePlace, descriptionPlace, buttonsPlace, buttonPrefab, imagePlace));
    }

    public static void SetNewEvent(Event newEvent)
    {
        _stateMachine.SetNewState(newEvent);
    }
}