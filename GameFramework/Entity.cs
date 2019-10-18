using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    delegate void Event();
    class Entity
    {
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;
        private Vector2 _location = new Vector2(0, 0);

        public char Icon { get; set; } = ' ';
        public float X
        {
            get
            {
                return _location.x;
            }
            set
            {
                _location.x = value;
            }
        }
        public float Y
        {
            get
            {
                return _location.y;
            }
            set
            {
                _location.y = value;
            }
        }
        private Scene _scene;

        public Entity()
        {

        }
        public Entity(char icon)
        {
            Icon = icon;
        }
        public void Start()
        {
            OnStart?.Invoke();
        }
        public void Update()
        {
            OnUpdate?.Invoke();
        }
        public void Draw()
        {
            OnDraw?.Invoke();
        }
        public Scene MyScene
        {
            set
            {
                _scene = value;
            }
            get
            {
                return _scene;
            }
        }
    }
}
