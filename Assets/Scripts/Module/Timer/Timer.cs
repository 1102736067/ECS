using System;
using System.Collections.Generic;
using System.Linq;

namespace Module.Timer
{
    /// <summary>
    /// ��ʱ���ӿ�
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// ��ǰ��ʱ��
        /// </summary>
        float CurrentTime { get; }
        /// <summary>
        /// ���аٷֱ�
        /// </summary>
        float Percent { get; }
        /// <summary>
        /// ����ѭ������ʱ��
        /// </summary>
        float Duration { get; }
        /// <summary>
        /// �Ƿ�ѭ��ִ��
        /// </summary>
        bool IsLoop { get; }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        bool IsComplete { get; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        void ResetData(float duration, bool loop);
        /// <summary>
        /// ֡����
        /// </summary>
        void Update();
        /// <summary>
        /// ������ʱ
        /// </summary>
        void Continue();
        /// <summary>
        /// ��ͣ��ʱ
        /// </summary>
        void Pause();
        /// <summary>
        /// ֹͣ��ʱ
        /// </summary>
        void Stop();

        void AddUpdateListener(Action update);
        void AddCompleteListener(Action complete);
    }

    public interface ITimerManager
    {
        /// <summary>
        /// ������ʱ��
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(float duration, bool loop);
        /// <summary>
        /// ֡����
        /// </summary>
        void Update();
        /// <summary>
        /// ����ִ�����м�ʱ��
        /// </summary>
        void ContinueAll();

        /// <summary>
        /// ��ͣ���м�ʱ��
        /// </summary>
        void PauseAll();
        /// <summary>
        /// �ر����м�ʱ��
        /// </summary>
        void StopAll();
    }

    /// <summary>
    /// ��ʱ��������
    /// </summary>
    public class TimerManager : ITimerManager
    {
        /// <summary>
        /// ��ʱ��
        /// </summary>
        private class Timer : ITimer
        {
            /// <summary>
            /// ��ǰ��ʱ��
            /// </summary>
            public float CurrentTime
            {
                get { return _runTimeTotal; }
            }

            /// <summary>
            /// ���аٷֱ�
            /// </summary>
            public float Percent
            {
                get { return _runTimeTotal / _duration; }
            }

            /// <summary>
            /// ����ѭ������ʱ��
            /// </summary>
            public float Duration { get { return _duration; } }
            //�Ƿ����
            public bool IsComplete
            {
                get { return _runTimeTotal >= _duration; }
            }
            //�Ƿ�ѭ��ִ��
            public bool IsLoop { get; private set; }

            private Action _onUpdate;
            private Action _onComplete;
            //�Ƿ����ڼ�ʱ
            private bool _isTiming;
            //��ʱ��ʼʱ��
            private DateTime _startTime;
            //������ʱ��
            private float _runTimeTotal;
           
            //����ʱ��
            private float _duration;

            public Timer(float duration, bool loop)
            {
                InitData(duration, loop);
            }


            private void InitData(float duration, bool loop)
            {
                _duration = duration;
                IsLoop = loop;
                ResetData();
            }

            public void ResetData(float duration, bool loop)
            {
                InitData(duration, loop);
            }

            private void ResetData()
            {
                _isTiming = true;
                _startTime = DateTime.Now;
                _runTimeTotal = 0;
            }

            public void Update()
            {
                if (!IsComplete || !_isTiming)
                    return;

                if (IsLoop)
                {
                    Loop();
                }
                else
                {
                    NotLoop();
                }

                _onUpdate?.Invoke();
            }

            private void Loop()
            {
                if (IsComplete)
                {
                    _onComplete?.Invoke();
                    ResetData();
                }
            }

            private void NotLoop()
            {
                if (IsComplete)
                {
                    _onComplete?.Invoke();
                }
            }

            public void Continue()
            {
                _isTiming = true;
                _startTime = DateTime.Now;
            }

            public void Pause()
            {
                _isTiming = false;
                _runTimeTotal += GetCurrentTimingTime();
            }

            public void Stop()
            {
                if (IsComplete)
                {
                    _onComplete?.Invoke();
                }
                _runTimeTotal = 0;
                _isTiming = false;
            }

            public void AddUpdateListener(Action update)
            {
                _onUpdate += update;
            }

            public void AddCompleteListener(Action complete)
            {
                _onComplete += complete;
            }

            private float GetCurrentTimingTime()
            {
                var time = DateTime.Now - _startTime;
                return (float)time.TotalSeconds;
            }
        }

        private HashSet<ITimer> _activeTimers;
        private HashSet<ITimer> _inactiveTimers;

        public TimerManager()
        {
            _activeTimers = new HashSet<ITimer>();
            _inactiveTimers = new HashSet<ITimer>();
        }

        /// <summary>
        /// �����¼�ʱ��
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public ITimer CreateTimer(float duration, bool loop)
        {
            ITimer timer = null;
            if (_inactiveTimers.Count >= 0)
            {
                timer = _inactiveTimers.First();
                _inactiveTimers.Remove(timer);
                timer.ResetData(duration,loop);
                _activeTimers.Add(timer);
            }
            else
            {
                timer = new Timer(duration, loop);
                _activeTimers.Add(timer);
            }

            return timer;
        }

        public void Update()
        {
            if (_activeTimers.Count > 0)
            {
                foreach (ITimer timer in _activeTimers)
                {
                    timer.Update();
                    SetInactiveTimer(timer);
                }
            }
        }

        /// <summary>
        /// ��ȡִ����ϵļ�ʱ�������뻺��
        /// </summary>
        /// <param name="timer"></param>
        private void SetInactiveTimer(ITimer timer)
        {
            if (!timer.IsLoop && timer.IsComplete)
            {
                _activeTimers.Remove(timer);
                _inactiveTimers.Add(timer);
            }
        }

        /// <summary>
        /// ����ִ�����м�ʱ��
        /// </summary>
        public void ContinueAll()
        {
            foreach (ITimer timer in _activeTimers)
            {
                timer.Continue();
            }
        }

        /// <summary>
        /// ��ͣ���м�ʱ��
        /// </summary>
        public void PauseAll()
        {
            foreach (ITimer timer in _activeTimers)
            {
                timer.Pause();
            }
        }

        /// <summary>
        /// �ر����м�ʱ��
        /// </summary>
        public void StopAll()
        {
            foreach (ITimer timer in _activeTimers)
            {
                timer.Stop();
            }
        }


    }
}
