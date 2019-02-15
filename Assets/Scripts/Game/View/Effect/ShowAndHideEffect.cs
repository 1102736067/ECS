using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.Effect
{
    public static class ShowAndHideEffect     
    {
        /// <summary>
        /// ���Ե�ǰ���弰�����������е�Image
        /// </summary>
        /// <param name="go"></param>
        /// <param name="duration"></param>
        public static void ShowAllImageEffect(this GameObject go,float duration)
        {
            foreach (Image image in go.GetComponentsInChildren<Image>())
            {
                KillImageEffect(image);
                image.DOFade(1,duration);
            }
        }


        /// <summary>
        /// ������ǰ���弰�����������е�Image
        /// </summary>
        /// <param name="go"></param>
        /// <param name="duration"></param>
        public static void HideAllImageEffect(this GameObject go, float duration)
        {
            foreach (Image image in go.GetComponentsInChildren<Image>())
            {
                KillImageEffect(image);
                image.DOFade(0, duration);
            }
        }

        private static void KillImageEffect(Image image)
        {
            image.DOKill();
        }
    }
}
