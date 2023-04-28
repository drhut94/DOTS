using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace GameOfLife.ECS.Systems
{
    public partial class GameOfLifeSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            foreach (TransformAspect transformAspect in SystemAPI.Query<TransformAspect>())
            {
                //transformAspect.Position += new float3(SystemAPI.Time.DeltaTime, 0, 0);
                transformAspect.TranslateWorld(new float3(SystemAPI.Time.DeltaTime, 0, 0));
            }
        }
    }
}