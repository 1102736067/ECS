

namespace Game
{
    /// <summary>
    /// ������Ϊ�ӿ�
    /// </summary>
    public interface IBehaviour
    {
        void Idle();
        /// <summary>
        /// ת��ǰ��
        /// </summary>
        void TurnForward();
        /// <summary>
        /// ת���
        /// </summary>
        void TurnBack();
        /// <summary>
        /// ת�����
        /// </summary>
        void TurnLeft();
        /// <summary>
        /// ת���Ҳ�
        /// </summary>
        void TurnRight();
        /// <summary>
        /// �ƶ�
        /// </summary>
        void Move();
    }

    /// <summary>
    /// �����Ϊ�ӿ�
    /// </summary>
    public interface IPlayerBehaviour : IBehaviour
    {
        /// <summary>
        /// ��ǰ�Ƿ����ܱ�־λ
        /// </summary>
        bool IsRun { get; set; }

        bool IsAttack { get;}

        /// <summary>
        /// ������
        /// </summary>
        void Attack(int skillCode);
    }
}
