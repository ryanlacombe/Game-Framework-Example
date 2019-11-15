using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class AABB
    {
       private Vector3 _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
       private Vector3 _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public AABB()
        {

        }
        public AABB(Vector3 min, Vector3 max)
        {
            _min = min;
            _max = max;
        }
        public Vector3 Center()
        {
            return (_min + _max) * 0.5f;
        }
        public Vector3 Extents()
        {
            return new Vector3(Math.Abs(_max.x - _min.x) * 0.5f, Math.Abs(_max.y - _min.y) * 0.5f, Math.Abs(_max.z - _min.z) * 0.5f);        
        }
        public List<Vector3> Corners()
        {
            List<Vector3> corners = new List<Vector3>(4);
            corners[0] = _min;
            corners[1] = new Vector3(_min.x, _max.y, _min.z);
            corners[2] = _max;
            corners[3] = new Vector3(_max.x, _min.y, _min.z);
            return corners;
        }
        public void Fit(List<Vector3> points)
        {
            _min = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
            _max = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

            foreach (Vector3 p in points)
            {
                _min = Vector3.Min(_min, p);
                _max = Vector3.Max(_max, p);
            }
        }
        public bool Overlaps(Vector3 p)
        {
            return !(p.x < _min.x || p.y < _min.y || p.x > _max.x || p.y > _max.y);
        }
        public bool Overlaps(AABB other)
        {
            return !(_max.x < other._min.x || _max.y < other._min.y || _min.x > other._max.x || _min.y > other._max.y);
        }
        public Vector3 ClosestPoint(Vector3 p)
        {
            return Vector3.Clamp(p, _min, _max);
        }
    }
}

