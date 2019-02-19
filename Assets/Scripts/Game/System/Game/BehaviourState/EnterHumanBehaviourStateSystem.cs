using System.Collections.Generic;

namespace Game
{
    //����Idle״̬
    public class GameEnterIdelStateSystem : GameHumanBehaviourStateEnterSystemBase
    {
        public GameEnterIdelStateSystem(Contexts context) : base(context)
        {
        }

        protected override bool StateConditon(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.Behaviour == PlayerBehaviourIndex.IDLE;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _contexts.game.gamePlayer.Behaviour.Idle();
        }
    }
    //����Walk״̬
    public class GameEnterWalkStateSystem : GameHumanBehaviourStateEnterSystemBase
    {
        public GameEnterWalkStateSystem(Contexts context) : base(context)
        {
        }

        protected override bool StateConditon(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.Behaviour == PlayerBehaviourIndex.WALK;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }

    //����Attack״̬
    public class GameEnterAttackStateSystem : GameHumanBehaviourStateEnterSystemBase
    {
        public GameEnterAttackStateSystem(Contexts context) : base(context)
        {
        }

        protected override bool StateConditon(GameEntity entity)
        {
            return entity.gameHumanBehaviourState.Behaviour == PlayerBehaviourIndex.ATTACK;
        }

        protected override void Execute(List<GameEntity> entities)
        {

        }
    }
}
