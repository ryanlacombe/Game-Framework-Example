﻿using System;
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
        private List<Entity>[,] _tracking;
        private List<Entity> _removals = new List<Entity>();
        private int _sizeX;
        private int _sizeY;
        private bool[,] _collision;

        public Scene(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _collision = new bool[_sizeX, _sizeY];
            _tracking = new List<Entity>[_sizeX, _sizeY];
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

            //Clear the collision grid
            _collision = new bool[_sizeX, _sizeY];
            //Clear the tracking grid
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    _tracking[x, y] = new List<Entity>();
                }
            }

            //Remove all the Entities readied for removal
            foreach (Entity e in _removals)
            {
                //Remove e from _entities
                _entities.Remove(e);
            }
            //Reset the removal list
            _removals.Clear();

            foreach (Entity e in _entities)
            {
                //Set the Entity's collision in the collision grid
                int x = (int)e.X;
                int y = (int)e.Y;
                //Only update if the Entity is within bounds
                if (x >= 0 && x < _sizeX
                    && y >= 0 && y < _sizeY)
                {
                    //Add the Entity to the tracking grid
                    _tracking[x, y].Add(e);
                    //Only update this point in the grid if the Entity is solid
                    if (!_collision[x, y])
                    {
                        _collision[x, y] = e.Solid;
                    }
                }
            }

            foreach (Entity e in _entities)
            {
                //Call the Entity's Update events
                e.Update();
            }
        }
        public void Draw()
        {
            OnDraw?.Invoke();

            Console.Clear();

            char[,] display = new char[_sizeX, _sizeY];

            foreach (Entity e in _entities)
            {               
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
            foreach (Entity e in _entities)
            {
                e.Draw();
            }
        }
        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
            entity.MyScene = this;
        }
        public void RemoveEntity(Entity entity)
        {
            //Ready the Entity for removal
            _removals.Add(entity);
            //Nullify the Entity's Scene
            entity.MyScene = null;
        }
        public void ClearEntities()
        {
            //Nullify each Entity's Scene
            foreach (Entity e in _entities)
            {
                RemoveEntity(e);
            }
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
        public List<Entity> GetEntities(float x, float y)
        {
            if (x >= 0 && y >= 0 && x < _sizeX && y < _sizeY)
            {
                return _tracking[(int)x, (int)y];
            }
            else
            {
                return new List<Entity>();
            }
        }
    }
}
