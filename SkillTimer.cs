using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Warmsnow_NewPotionSystem
{
    public enum SkillTimerStatus
    {
        Ready,
        Running,
        Stop,
        CoolDown,
    }

    public class SkillTimer
    {
        public delegate void SkillTimerUpdateHandler(float deltaTime);
        SkillTimerStatus _status = SkillTimerStatus.Ready;
        public bool IsRunning { get; set; } = false;
        public float Period { get; set; }
        public float CoolDown { get; set; }
        public float Counter { get; set; }
        public Action CallBack { get; set; }
        public SkillTimer(float period, float coolDown, Action skillEndCallback) 
        { 
            Period = period;
            CoolDown = coolDown;
            CallBack = skillEndCallback;
            Counter = 0;
        }
        public void OnUpdate(float deltaTime)
        {
            if (deltaTime <= 0)
            {
                return;
            }
            if (_status == SkillTimerStatus.Ready)
            {
                _status = IsRunning ? SkillTimerStatus.Running : SkillTimerStatus.Ready;
            }
            else if (_status == SkillTimerStatus.Running)
            {
                Counter += deltaTime;
                if (Counter >= Period)
                {
                    _status = SkillTimerStatus.Stop;
                    Counter = 0;
                    return;
                }
                return;
            }
            else if (_status == SkillTimerStatus.Stop)
            {
                _status = SkillTimerStatus.CoolDown;
                CallBack?.Invoke();
                return;
            }
            else if (_status == SkillTimerStatus.CoolDown)
            {
                Counter += deltaTime;
                if (Counter >= CoolDown)
                {
                    IsRunning = false;
                    _status = SkillTimerStatus.Ready;
                    Counter = 0;
                    return;
                }
                return;
            }
        }
    }
}
