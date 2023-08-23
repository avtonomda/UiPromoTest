using System.Collections;
using UnityEngine;

namespace RedPanda.Project.Extensions
{
    public static class TransformExtension
    {
        public static IEnumerator ScaleUpAndReset(
            this Transform targetTransform,
            Vector3 toScale,
            float duration)
        {
            var initialScale = targetTransform.localScale;
            var elapsedTime = 0f;
            var halfDuration = duration / 2f;
            
            while (elapsedTime < halfDuration)
            {
                targetTransform.localScale = Vector3.Lerp(initialScale, toScale, elapsedTime / halfDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
            while (elapsedTime < duration)
            {
                targetTransform.localScale = Vector3.Lerp(toScale, initialScale, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            targetTransform.localScale = initialScale;
        }
    }
}
