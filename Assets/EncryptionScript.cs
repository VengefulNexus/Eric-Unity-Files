using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EncryptionScript : MonoBehaviour {
    public static string EncryptString(string data)     //call to encrypt a string by shiftin the ascii values by BombAssShift value
    {
        const int BombAssShift = 69;            //an ascii value shift amount
        string encryptedString = "";            //placeholder to add each encrypted character to 
        foreach (char value in data)            //for each character in the string
        {
            encryptedString += (char)((int)value + BombAssShift);   //first convert the character to int to get ascii value, add the shift to the int value, and then convert that int back to a char and add it to the end of the encrypted string
        }
        return encryptedString;     //return the encrypted string
    }

    public static string DecryptString(string data)     //same thing as the encrypt string except subtract the shift amount rather than add it to undo the encryption
    {
        const int BombAssShift = 69;
        string encryptedString = "";
        foreach (char value in data)
        {
            encryptedString += (char)((int)value - BombAssShift);
        }
        return encryptedString;
    }
}
