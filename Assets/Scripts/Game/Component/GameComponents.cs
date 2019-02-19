using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Game
{
    /// <summary>
    /// �������״̬ ���ݴ�״̬�ĸı䲥���������
    /// </summary>
    [Game,Event(EventTarget.Self),Unique]
    public class CameraState : IComponent
    {
        public CameraAniName State;
    }

    /// <summary>
    /// ��Ϸ״̬
    /// </summary>
    [Game,Unique]
    public class GameStateComponent : IComponent
    {
        public GameState GameState;
    }

    /// <summary>
    /// ���
    /// </summary>
    [Game,Unique]
    public class PlayerComponent : IComponent
    {
        public IView Player;
        public IPlayerBehaviour Behaviour;
        public IPlayerAni Ani;
    }

    /// <summary>
    /// ��Ҷ���
    /// </summary>
    [Game]
    public class PlayerAniState : IComponent
    {
        public PlayerAniIndex AniIndex;
    }

    /// <summary>
    /// �������＼�ܲ���
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class ValidHumanSkillComponent : IComponent
    {
        /// <summary>
        /// ���ܱ���
        /// </summary>
        public int SkillCode;
    }

    /// <summary>
    /// �������＼�ܲ���
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class PlayHumanSkillComponent : IComponent
    {
        /// <summary>
        /// ���ܱ���
        /// </summary>
        public int SkillCode;
    }

    [Game, Unique]
    public class HumanBehaviourStateComponent : IComponent
    {
        public PlayerBehaviourIndex Behaviour;
        public BehaviorState State;
    }

    /// <summary>
    /// ���＼�ܿ�ʼ�¼�
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class StartHumanSkillComponent : IComponent
    {
        /// <summary>
        /// ���ܱ���
        /// </summary>
        public int SkillCode;
    }

    /// <summary>
    /// ���＼�ܽ����¼�
    /// </summary>
    [Game, Unique, Event(EventTarget.Any)]
    public class EndHumanSkillComponent : IComponent
    {
        /// <summary>
        /// ���ܱ���
        /// </summary>
        public int SkillCode;
    }
}
