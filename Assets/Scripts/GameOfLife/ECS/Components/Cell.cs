using Unity.Entities;

namespace GameOfLife.ECS.Components
{
    public struct Cell : IComponentData
    {
        public int alive;
    }
}