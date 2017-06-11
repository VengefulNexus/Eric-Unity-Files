using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EncryptionScript : MonoBehaviour {
    public static string EncryptString(string data)
    {
        const int BombAssShift = 69;
        string encryptedString = "";
        foreach (char value in data)
        {
            encryptedString += (char)((int)value + BombAssShift);
        }
        return encryptedString;
    }
}
