using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Scriptable Objects/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] public float WalkSpeed = 50;
    [SerializeField] public float JumpPower = 5;

}
