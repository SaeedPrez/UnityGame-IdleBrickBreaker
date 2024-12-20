﻿using ES3Editor;
using UnityEditor;
using UnityEngine;

namespace ES3Internal
{
    [CustomEditor(typeof(ES3AutoSaveMgr))]
    public class ES3AutoSaveMgrEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox(
                "This manages the saving and loading of GameObjects which have the Auto Save component attached to them.\n\nIf there are no Auto Save components in your scene, this component will do nothing.",
                MessageType.Info);
            if (GUILayout.Button("Settings..."))
                ES3Window.InitAndShowAutoSave();
        }
    }
}