using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public abstract class PlayerAttribute : MonoBehaviour {
    public bool displayInUI = true;
    PlayerScript pScript;
    public abstract string GetUIString();
}
