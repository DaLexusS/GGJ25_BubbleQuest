using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float WalkSpeed = 50;
    public float JumpPower = 5;

}
