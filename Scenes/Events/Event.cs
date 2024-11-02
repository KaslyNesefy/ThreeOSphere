using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public abstract class Event : State
{
    private string _path;
    private const string _XMLMAINFOLDERPATH = "Assets/ThreeOSphere/Scenes/XML";
    private protected EventInfo _eventInfo;

    private protected List<string> _nextEventButtonsTexts = new List<string>();
    private protected List<Event> _nextEvents = new List<Event>();

    private protected EventPattern _eventPattern;

    public Event(EventPattern eventPattern) => _eventPattern = eventPattern;

    public override void Enter()
    {
        base.Enter();
        SetXMLFilePath();
        Debug.Log("We are here: " + _path);
        BuildEvent();
        Debug.Log("Current Event: " + _eventInfo.Title);
    }
    public override void Exit()
    {
        base.Exit();
        _nextEventButtonsTexts.Clear();
        _nextEvents.Clear();
        foreach (Transform child in _eventPattern.ButtonsPlace.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    private protected void BuildEvent()
    {
        GetInfoFromXML();
        SetParts();
    }
    private void GetInfoFromXML()
    {
        foreach (XmlNode node in GetXMLRoot())
        {
            switch (node.Name)
            {
                case "Id": { _eventInfo.Id = node.InnerText; } break;
                case "Title": { _eventInfo.Title = node.InnerText; } break;
                case "Description": { _eventInfo.Description = node.InnerText; } break;
                case "ButtonText": { _nextEventButtonsTexts.Add(node.InnerText); } break;
                default: { Debug.LogError("Your XML is a piece of sht."); return; }
            }
        }
    }
    private void SetParts()
    {
        SetInfo();
        SetButtons();
    }
    private void SetInfo()
    {
        //_nameTMP.text = _name;
        //_descriptionTMP.text = _description;
        //eventPattern.NamePlace.text = _name;
        //eventPattern.DescriptionPlace.text = _description;
        _eventPattern.NamePlace.text = _eventInfo.Title;
        _eventPattern.DescriptionPlace.text = _eventInfo.Description;
    }
    private void SetButtons()
    {
        string[] buttonsTexts = _nextEventButtonsTexts.ToArray();
        Event[] nextEvents = _nextEvents.ToArray();
        if (buttonsTexts.Length == 0)
        {
            Debug.LogError("No buttons texts detected!");
            return;
        }
        if (nextEvents.Length == 0)
        {
            Debug.LogError("No buttons events detected!");
            return;
        }
        if (buttonsTexts.Length > nextEvents.Length)
        {
            Debug.LogError("Not enough event references!");
            return;
        }
        if (buttonsTexts.Length < nextEvents.Length)
        {
            Debug.LogError("Not enough buttons texts!");
            return;
        }
        byte buttonsAmount = (byte)buttonsTexts.Length;
        for (byte i = 0; i < buttonsAmount; i++)
        {
            GameObject newButton = GameObject.Instantiate(_eventPattern.ButtonPrefab);
            newButton.transform.SetParent(_eventPattern.ButtonsPlace.transform);
            newButton.GetComponent<NextEventButton>().SetButton(buttonsTexts[i], nextEvents[i]);
        }
    }
    private XmlNode GetXMLRoot()
    {
        if ((_path is null) || (_path == ""))
        {
            Debug.LogError("Path to XML is null or empty!");
            return null;
        }

        XmlDocument _xmlDocument = new XmlDocument();
        _xmlDocument.Load(_path);
        XmlElement xmlRoot = _xmlDocument.DocumentElement;

        if (xmlRoot is null)
        {
            Debug.LogError("Root element is null!");
            return null;
        }
        if (xmlRoot.Name != "Event")
        {
            Debug.LogError("Incorrect root element!");
            return null;
        }

        return xmlRoot;
    }
    private protected void SetXMLFilePath()
    {
        if (_eventInfo.XmlFileName.EndsWith(".xml", System.StringComparison.CurrentCultureIgnoreCase))
        {
            Debug.LogError("Use nameof(EventClassName), no hands!");
            return;
        }
        if (string.IsNullOrEmpty(_eventInfo.XmlFileName))
        {
            Debug.LogError("XML filename is null or empty!");
            return;
        }
        if (_eventInfo.XmlFolderPath is null)
        {
            Debug.LogError("XML file folder path is null or empty!");
            return;
        }
        _eventInfo.XmlFileName = string.Concat(_eventInfo.XmlFileName, ".xml");
        _path = Path.Combine(_XMLMAINFOLDERPATH, _eventInfo.XmlFolderPath, _eventInfo.XmlFileName);
    }
}
