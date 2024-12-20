﻿using UnityEditor;

[CustomEditor(typeof(ES3InspectorInfo))]
public class ES3InspectorInfoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox(((ES3InspectorInfo)target).message, MessageType.Info);
    }
}