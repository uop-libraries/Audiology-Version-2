using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this class as global variable holder
public class StateNameController : MonoBehaviour
{
    private static int _clinicalCaseNumber;
    private static GameObject _currentActivePanel;
    private static bool _isClicked;
    private static bool _isVideoPlaying;
    private static bool _isGameStarted;
    private static bool _isCase1HistoryDone;
    private static bool _isCase2HistoryDone;

    public static void SetClinicalCaseNumber(int value)
    {
        _clinicalCaseNumber = value;
    }
    
    public static int GetClinicalCaseNumber()
    {
        return _clinicalCaseNumber;
    }

    public static void SetCurrentActivePanel(GameObject nextObject)
    {
        _currentActivePanel = nextObject;
    }

    public static GameObject GetCurrentActivePanel()
    {
        return _currentActivePanel;
    }

    public static void SetIsClicked(bool value)
    {
        _isClicked = value;
    }

    public static bool GetIsClicked()
    {
        return _isClicked;
    }

    public static void SetIsVideoPlaying(bool value)
    {
        _isVideoPlaying = value;
    }

    public static bool GetIsVideoPlaying()
    {
        return _isVideoPlaying;
    }

    public static void SetIsGameStarted(bool value)
    {
        _isGameStarted = value;
    }

    public static bool GetIsGameStarted()
    {
        return _isGameStarted;
    }
    
    public static void SetIsCase1HistoryDone(bool value)
    {
        _isCase1HistoryDone = value;
    }
    
    public static bool GetIsCase1HistoryDone()
    {
        return _isCase1HistoryDone;
    }
    
    public static void SetIsCase2HistoryDone(bool value)
    {
        _isCase2HistoryDone = value;
    }
    
    public static bool GetIsCase2HistoryDone()
    {
        return _isCase2HistoryDone;
    }
}
