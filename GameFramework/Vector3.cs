﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;
        }
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }
        public static Vector3 operator /(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }
        public float Distance(Vector3 other)
        {
            float diffX = x - other.x;
            float diffY = y - other.y;
            float diffZ = z - other.z;

            return (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }
        public Vector3 GetNormalized()
        {
            return (this / Magnitude());
        }
        public float Dot(Vector3 other)
        {
            float A = x * other.x;
            float B = y * other.y;
            float C = z * other.z;
            float result = A + B + C;
            return result;
        }

        public Vector3 Cross(Vector3 other)
        {
            float X = (x * other.z) - (z * other.y);
            float Y = (z * other.x) - (x * other.z);
            float Z = (x * other.y) - (y * other.x);
            Vector3 result = new Vector3(X, Y, Z);
            return result;
        }
        public float AngleBetween(Vector3 other)
        {
            Vector3 a = GetNormalized();
            Vector3 b = other.GetNormalized();

            return (float)Math.Acos(a.Dot(b));
        }
        public override string ToString()
        {
            return "{" + x + ", " + y + ", " + z + "}";
        }
    }
}
