using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Module.Timer
{
    /// <summary>
    /// ��ʱ���ӿ�
    /// </summary>
    public interface ITimer
    {
        /// <summary>
        /// ��ʱ��Ψһ��ʶ
        /// </summary>
        string ID { get; }

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
        /// �Ƿ����ڼ�ʱ
        /// </summary>
        bool IsTiming { get; }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        bool IsComplete { get; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        void ResetData(string id, float duration, bool loop);
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
        void Stop(bool isComplete);

        ITimer AddUpdateListener(Action update);
        ITimer AddCompleteListener(Action complete);
    }

    public interface ITimerManager
    {
        /// <summary>
        /// ������ʱ�����統ǰָ�����Ƽ�ʱ�����ڼ�ʱ������null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreateTimer(string id, float duration, bool loop);

        /// <summary>
        /// ����ָ��ID��Timer����
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer ResetTimerData(string id, float duration, bool loop);
        /// <summary>
        /// ָ��ID��timerΪ�գ�����timer����Ϊ�գ���������timer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        ITimer CreatOrRestartTimer(string id, float duration, bool loop);
        /// <summary>
        /// ͨ����ʶ��ȡ��ʱ��
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ITimer GeTimer(string id);

        void StopTimer(ITimer timer, bool isComplete);

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
            public string ID { get; private set; }

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
            public bool IsComplete { get; private set; }
            //�Ƿ�ѭ��ִ��
            public bool IsLoop { get; private set; }
            //�Ƿ����ڼ�ʱ
            public bool IsTiming { get; private set; }

            private Action _onUpdate;
            private Action _onComplete;

            //��ʱ��ʼʱ��
            private DateTime _startTime;
            //������ʱ��
            private float _runTimeTotal;

            //����ʱ��
            private float _duration;
            //ˢ�¼��֡��
            private int _offsetFrame = 5;
            private int _frameTimes;

            public Timer(string id, float duration, bool loop)
            {
                InitData(id, duration, loop);
            }


            private void InitData(string id, float duration, bool loop)
            {
                ID = id;
                _duration = duration;
                IsLoop = loop;
                ResetData();
            }

            /// <summary>
            /// ��������
            /// </summary>
            /// <param name="id"></param>
            /// <param name="duration"></param>
            /// <param name="loop"></param>
            public void ResetData(string id, float duration, bool loop)
            {
                InitData(id, duration, loop);
            }

            private void ResetData()
            {
                IsComplete = false;
                IsTiming = true;
                _startTime = DateTime.Now;
                _runTimeTotal = 0;
                _onUpdate = null;
                _onComplete = null;
            }

            public void Update()
            {
                _frameTimes++;
                if (_frameTimes < _offsetFrame)
                    return;
                _frameTimes = 0;

                if (IsComplete || !IsTiming)
                    return;

                IsComplete = JudgeIsComplete();

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
                    IsComplete = false;
                    _onComplete?.Invoke();
                    ResetData();
                }
            }

            private void NotLoop()
            {
                if (IsComplete)
                {
                    _onComplete?.Invoke();
                    _onComplete = null;
                }
            }

            public void Continue()
            {
                IsTiming = true;
                _startTime = DateTime.Now;
            }

            public void Pause()
            {
                IsTiming = false;
                _runTimeTotal += GetCurrentTimingTime();
            }

            public void Stop(bool isComplete)
            {
                if (IsComplete && isComplete)
                {
                    _onComplete?.Invoke();
                }
                _onComplete = null;
                _runTimeTotal = 0;
                IsTiming = false;
            }

            public ITimer AddUpdateListener(Action update)
            {
                _onUpdate += update;
                return this;
            }

            public ITimer AddCompleteListener(Action complete)
            {
                _onComplete += complete;
                return this;
            }

            private float GetCurrentTimingTime()
            {
                var time = DateTime.Now - _startTime;
                return (float)time.TotalSeconds;
            }
            /// <summary>
            /// �жϵ�ǰ�Ƿ�ִ�����
            /// </summary>
            /// <returns></returns>
            private bool JudgeIsComplete()
            {
                return (_runTimeTotal + GetCurrentTimingTime()) >= _duration;
            }
        }

        private HashSet<ITimer> _activeTimers;
        private HashSet<ITimer> _inactiveTimers;
        private HashSet<ITimer>.Enumerator _activEnum;
        private Dictionary<string, ITimer> _timersDic;

        public TimerManager()
        {
            _activeTimers = new HashSet<ITimer>();
            _inactiveTimers = new HashSet<ITimer>();
            _timersDic = new Dictionary<string, ITimer>();
        }

        /// <summary>
        /// �����¼�ʱ��
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        public ITimer CreateTimer(string id, float duration, bool loop)
        {
            ITimer timer = null;
            if (_timersDic.ContainsKey(id))
            {
                timer = _timersDic[id];
                if (!timer.IsTiming)
                {
                    ResetTimer(timer,id, duration, loop);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (_inactiveTimers.Count > 0)
                {
                    timer = _inactiveTimers.First();

                    _timersDic.Remove(timer.ID);
                    
                    ResetTimer(timer, id, duration, loop);
                }
                else
                {
                    timer = new Timer(id, duration, loop);
                    _activeTimers.Add(timer);
                }
                _timersDic[id] = timer;
            }

            timer.AddCompleteListener(() => TimerComplete(timer));
            return timer;
        }

        public ITimer ResetTimerData(string id, float duration, bool loop)
        {
            if (_timersDic.ContainsKey(id))
            {
                var timer = _timersDic[id];
                if (timer.IsTiming)
                {
                    ResetTimer(timer, id, duration, loop);
                }

                return timer;
            }

            return null;
        }

        public ITimer CreatOrRestartTimer(string id, float duration, bool loop)
        {
            var timer = CreateTimer(id, duration, loop);

            if (timer == null)
            {
                timer = ResetTimerData(id, duration, loop);
            }

            return timer;
        }

        private void ResetTimer(ITimer timer, string id, float duration, bool loop)
        {
            if (_inactiveTimers.Contains(timer))
            {
                _inactiveTimers.Remove(timer);
                _activeTimers.Add(timer);
            }
           
            timer.ResetData(id, duration, loop);
        }

        public void StopTimer(ITimer timer,bool isComplete)
        {
            timer.Stop(isComplete);
            SetInactiveTimer(timer);
        }

        public ITimer GeTimer(string id)
        {
            if (_timersDic.ContainsKey(id))
            {
                return _timersDic[id];
            }
            else
            {
                return null;
            }
        }

        private void TimerComplete(ITimer timer)
        {
            if (!timer.IsLoop)
            {
                SetInactiveTimer(timer);
            }
        }

        private void SetInactiveTimer(ITimer timer)
        {
            if (_activeTimers.Contains(timer))
            {
                _activeTimers.Remove(timer);
                _inactiveTimers.Add(timer);
            }
        }

        public void Update()
        {
            _activEnum = _activeTimers.GetEnumerator();
            int count = _activeTimers.Count;

            try
            {
                for (int i = 0; i < count; i++)
                {
                    if (!_activEnum.MoveNext())
                    {
                        continue;
                    }
                    else
                    {
                        _activEnum.Current.Update();
                    }
                }
            }
            catch (Exception)
            {
                
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
                StopTimer(timer, false);
            }
        }


    }
}
