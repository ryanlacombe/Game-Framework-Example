using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Vector2
    {
        public float x;
        public float y;
        public float num;

        public Vector2(float X, float Y)
        {
            x = X;
            y = Y;
        }
        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }
        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }
        public static Vector2 operator *(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }
        public static Vector2 operator *(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
        }
        public static Vector2 operator /(Vector2 lhs, float rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }
        public static Vector2 operator /(float lhs, Vector2 rhs)
        {
            return new Vector2(lhs / rhs.x, lhs / rhs.y);
        }
        public static Vector2 operator ==(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x = rhs.x, lhs.y = rhs.y);
        }
        public static Vector2 operator !=(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x = rhs.x, lhs.x = rhs.y);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
        }
        public Vector2 GetNormalized()
        {
            return (this / Magnitude());
        }
        public float Dot(Vector2 other)
        {
            float A = x * other.x;
            float B = y * other.y;
            float result = A + B;
            return result;
        }
        
        public float AngleBetween(Vector2 other)
        {
            Vector2 a = GetNormalized();
            Vector2 b = other.GetNormalized();

            float d = a.x * b.x + a.y * b.y;
            return (float)Math.Acos(d);
        }
    }
}
