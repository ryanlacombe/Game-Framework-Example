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
        private List<Entity> _entities = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
        }
        public Scene()
        {
            _sizeX = 24;
            _sizeY = 24;
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
            foreach (Entity e in _entities)
            {
                e.Start();
            }
        }
        public void Update()
        {
            foreach (Entity e in _entities)
            {
                e.Update();
            }
        }
        public void Draw()
        {
            Console.Clear();

            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {
                e.Draw();
                if (e.X >= 0 && e.X < display.Length && e.Y >= 0 && e.Y < _sizeY)
                {
                    display[e.X, e.Y] = e.Icon;
                }
            }
            for (int o = 0; o < _sizeX; o++)
            {
                for (int i = 0; i < _sizeY; i++)
                {
                    Console.Write(display[i, o]);
                }
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
    }
}
