using System;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Vector3Serializable
{
    public float x, y, z;

    public Vector3Serializable()
    {
    }

    public Vector3Serializable(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Vector3Serializable(Vector3 vector3)
    {
        this.x = vector3.x;
        this.y = vector3.y;
        this.z = vector3.z;
    }

    public static bool operator ==(Vector3Serializable b, Vector3Serializable c)
    {
        return b.Equals(c);
    }

    public static bool operator !=(Vector3Serializable b, Vector3Serializable c)
    {
        return !b.Equals(c);
    }

    public static bool operator ==(Vector3Serializable b, Vector3Int c)
    {
        return b.Equals(c);
    }

    public static bool operator !=(Vector3Serializable b, Vector3Int c)
    {
        return !b.Equals(c);
    }

    public override bool Equals(object obj)
    {
        if (obj is Vector3Serializable serializable)
            return x == serializable.x &&
            y == serializable.y &&
               z == serializable.z;
        else
        {
            if (obj is Vector3Int vector3Int)
                return x == vector3Int.x &&
                y == vector3Int.y &&
                   z == vector3Int.z;
            else return false;
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y, z);
    }

    public static explicit operator Vector3Int(Vector3Serializable obj)
    {
        return new Vector3Int((int)obj.x, (int)obj.y, (int)obj.z);
    }
}
