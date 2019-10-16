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
        private int _size;

        public Scene(int size)
        {
            _size = size;
        }
        public Scene()
        {
            _size = 24;
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

            char[] display = new char[_size];

            foreach (Entity e in _entities)
            {
                e.Draw();
                if (e.X >= 0 && e.X < display.Length)
                {
                    display[e.X] = e.Icon;
                }
            }
            for (int i = 0; i < _size; i++)
            {
                Console.Write(display[i]);
            }
        }
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }
        public void RemoveEntity(Entity entity)
        {
            _entities.Remove(entity);
        }
        public void ClearEntities()
        {
            _entities.Clear();
        }
    }
}
