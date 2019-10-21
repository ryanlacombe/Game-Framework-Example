using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    class Scene
    {
        public Event OnStart;
        public Event OnUpdate;
        public Event OnDraw;
        private List<Entity> _entities = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        private bool[,] _collision;

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _collision = new bool[_sizeX, _sizeY];
        }
        public Scene() : this(24, 12)
        {
            
        }
        public int SizeX
        {
            get
            {
                return _sizeX;
            }
        }
        public int SizeY
        {
            get
            {
                return _sizeY;
            }
        }
        public void Start()
        {
            OnStart?.Invoke();

            foreach (Entity e in _entities)
            {
                e.Start();
            }
        }
        public void Update()
        {
            OnUpdate?.Invoke();

            _collision = new bool[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                e.Update();
                int x = (int)e.X;
                int y = (int)e.Y;
                if (e.X >= 0 && e.X < _sizeX && e.Y >= 0 && e.Y < _sizeY)
                {
                    if (!_collision[x, y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }
            }
        }
        public void Draw()
        {
            OnDraw?.Invoke();

            Console.Clear();

            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                e.Draw();
                if (e.X >= 0 && e.X < display.Length && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[(int)e.X, (int)e.Y] = e.Icon;
                }
            }
            for (int o = 0; o < _sizeY; o++)
            {
                for (int i = 0; i < _sizeX; i++)
                {
                    Console.Write(display[i, o]);
                }
                Console.WriteLine();
            }
        }
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = this;
        }
        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
            entity.MyScene = null;
        }
        public void ClearEntities()
        {
            foreach (Entity e in _entities)
            {
                e.MyScene = null;
            }
            _entities.Clear();
        }
        public bool GetCollision(float x, float y)
        {
            if (x >=0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _collision[(int)x, (int)y];
            }
            else
            {
                return false;
            }
        }
    }
}
