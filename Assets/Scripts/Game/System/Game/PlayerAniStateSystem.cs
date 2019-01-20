using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���ﶯ��״̬�ı���Ӧϵͳ
    /// </summary>
    public class PlayerAniStateSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        public PlayerAniStateSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GamePlayerAniState);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGamePlayerAniState;
        }

        protected override void Execute(List<GameEntity> entities)
        {
           //
        }
    }
}
