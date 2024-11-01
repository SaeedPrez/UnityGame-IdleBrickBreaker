using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[ExecuteInEditMode]
public class ES3GameObject : MonoBehaviour
{
    public List<Component> components = new();

    /* Ensures that this Component is always last in the List to guarantee that it's loaded after any Components it references */
    private void Update()
    {
        if (Application.isPlaying)
            return;

#if UNITY_EDITOR
        ComponentUtility.MoveComponentDown(this);
#endif
    }
}