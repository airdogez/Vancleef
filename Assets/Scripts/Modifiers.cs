using UnityEngine;
using System.Collections;

public class Modifiers {

    private static Modifiers instance;
    public static Modifiers Instance
    {
        get { return instance ?? (instance = new Modifiers()); }
    }

    public float globalSpeedModifier = 1f;
    public float playerSpeedModifier = 1f;

}
