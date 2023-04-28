using GameOfLife.ECS.Authoring;
using GameOfLife.ECS.Components;
using Unity.Entities;
using UnityEngine;

namespace GameOfLife.ECS.Authoring
{
    public class CellAuthoring : MonoBehaviour
    {
        public int alive;
    }
    
    public class CellBaker : Baker<CellAuthoring>
    {
        public override void Bake(CellAuthoring authoring)
        {
            AddComponent(new Cell
            {
                alive = authoring.alive
            });            
            
            //AddComponent(new Disabled());
        }
    }
}

