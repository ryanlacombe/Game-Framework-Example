using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GameFramework
{
    class Timer
    {
        Stopwatch stopwatch = new Stopwatch();
        private long _currentTime = 0;
        private long _previousTime = 0;
        private float _deltaTime = 0.005f;

        public Timer()
        {
            stopwatch.Start();
        }
        public void Restart()
        {
            stopwatch.Restart();
        }
        public float Seconds
        {
            get
            {
                return stopwatch.ElapsedMilliseconds / 1000.0f;
            }
        }
        public float GetDeltaTime()
        {
            _previousTime = _currentTime;
            _currentTime = stopwatch.ElapsedMilliseconds;
            _deltaTime = (_currentTime - _previousTime) / 1000.0f;
            return _deltaTime;
        }
    }
}
