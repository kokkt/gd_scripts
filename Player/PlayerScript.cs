using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class PlayerScript : MonoBehaviour
{
    public string gameOverScene = "GameOver";
    public static PlayerAttribute[] attributes;
    // Use this for initialization
    void Start()
    {
        tag = "Player";
        name = "Player";
        attributes = GetComponents<PlayerAttribute>();
        Debug.Log("Attributes: " + attributes.Length);
    }
    void Update()
    {

    }
    public static PlayerAttribute GetAttribute(System.Type type)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            if (attributes[i].GetType().Equals(type))
            {
                return attributes[i];
            }
        }
        return null;
    
    }
    public void GameOver(bool win)
    {
        /* Insert code that happens when the game is over */
        Application.LoadLevel(gameOverScene);
    }
    void OnGUI()
    {
        GUILayout.Space(64);
        for (int i = 0; i < attributes.Length; i++)
        {
            PlayerAttribute attr = attributes[i];
            if (attr.displayInUI)
            {
                GUILayout.Label(attr.GetUIString());
            }
        }
    }
}
