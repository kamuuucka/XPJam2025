using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType
    {
        Green = 0,
        Blue = 1,
        Red = 2, 
        Yellow =3
    }

    public PlatformType platformType;
}
