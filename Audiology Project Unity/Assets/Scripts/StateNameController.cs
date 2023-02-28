using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use this class as global variable holder
public class StateNameController : MonoBehaviour
{
    public static int ClinicalCaseNumber { get; set; }

    public static GameObject CurrentActivePanel { get; set; }

    public static bool IsClick { get; set; }

    public static bool IsVideoPlaying { get; set; }

    public static bool IsStart { get; set; }

    public static bool IsCase1HistoryDone { get; set; }

    public static bool IsCase2HistoryDone { get; set; }
}

