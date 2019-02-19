using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// �������ֽӿ�
    /// </summary>
    public interface IAni
    {
        void Play(int aniIndex);

        ICustomAniEventManager AniEventManager { get; set; }
    }

    public interface IPlayerAni : IAni,IPlayerBehaviour
    {

    }
}
