using UnityEngine;

namespace Game
{
    /// <summary>
    /// ������Ϊ�ӿ�
    /// </summary>
    public interface IBehaviour
    {
        void Up();
        void Down();
        void Left();
        void Right();
    }

    /// <summary>
    /// �����Ϊ�ӿ�
    /// </summary>
    public interface IPlayerBehaviour : IBehaviour
    {
        /// <summary>
        /// ������������K��
        /// </summary>
        void AttackO();
        /// <summary>
        /// ������ ������L��
        /// </summary>
        void AttackX();
    }

    public class PlayerBehaviourService : IPlayerBehaviour
    {
        public void Up()
        {
            throw new System.NotImplementedException();
        }

        public void Down()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }

        public void AttackO()
        {
            throw new System.NotImplementedException();
        }

        public void AttackX()
        {
            throw new System.NotImplementedException();
        }
    }
}
