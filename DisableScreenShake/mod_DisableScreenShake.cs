using Game;
using Patchwork;
using Onyx;
using UnityEngine;

namespace lukeee_g_DisableScreenShake
{
    [ModifiesType]
    public class Lukeee_gCameraControl : CameraControl
    {
        [ModifiesMember("HandleAndApplyCameraOffsets")]
        private void HandleAndApplyCameraOffsets(Camera curCamera)
        {
            Vector3 position = base.transform.position;
            Vector3 vector = Vector3.zero;
            // Commented the code below responsible for the Screen Shake
            //if (this.m_screenShakeTimer > 0f)
            //{
            //    this.m_screenShakeTimer -= TimeController.UnscaledDeltaTime;
            //    Vector3 vector2 = UnityEngine.Random.onUnitSphere * this.m_screenShakeStrength * (this.m_screenShakeTimer / this.m_screenShakeTotalTime);
            //    vector += vector2.x * -curCamera.transform.right;
            //    vector += vector2.y * -curCamera.transform.up;
            //}
            Vector3 vector3 = Vector3.zero;
            float num = 0f;
            if (GameState.Instance.CurrentMapIsSeaMap)
            {
                float num2 = Mathf.Sin(SingletonBehavior<TimeController>.Instance.GameTimeSinceStartup * this.SeaBobSpeed);
                vector3 += num2 * this.SeaBobStrength * -curCamera.transform.up;
                num += Mathf.Sin(SingletonBehavior<TimeController>.Instance.GameTimeSinceStartup * this.SeaBobRotationSpeed) * this.SeaBobMaxRotation;
            }
            base.transform.position += vector;
            if (GameState.Instance.CurrentMapIsSeaMap && GameState.Option.GetOption(GameOption.BoolOption.CAMERA_SEA_BOB))
            {
                base.transform.position += vector3;
                if (Time.deltaTime > 0f)
                {
                    base.transform.Rotate(Vector3.forward, num);
                }
            }
            if (position != base.transform.position)
            {
                this.ResetAtEdges();
                this.HandleCameraEdgeBounds(curCamera);
            }
        }
    }
}
