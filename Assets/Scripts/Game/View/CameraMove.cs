using System;
using UnityEngine;
using DG.Tweening;

namespace Game
{
    /// <summary>
    /// �����������
    /// </summary>
    public class CameraMove : MonoBehaviour     
    {
        /// <summary>
        /// ��ʼ��
        /// </summary>
        /// <param name="targetParent"></param>
        public void Init(Transform targetParent)
        {
            SetParent(targetParent);
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="targetParent"></param>
        public void Move(Transform targetParent,Action callBack)
        {
            SetParent(targetParent);

            float time = 2;

            transform.DOKill();
            transform.DOLocalMove(Vector3.zero, time);
            transform.DOLocalRotate(Vector3.zero, time).OnComplete(()=> callBack?.Invoke());
        }

        /// <summary>
        /// ���ø�����
        /// </summary>
        /// <param name="targetParent"></param>
        public void SetParent(Transform targetParent)
        {
            transform.SetParent(targetParent); transform.SetParent(targetParent);
        }
    }
}
