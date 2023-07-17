using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Warmsnow_NewPotionSystem
{
    /// <summary>
    /// 脑子圣物
    /// </summary>
    public class BrainPotion : Potion
    {
        //使用event以简化update方法的观感
        event SkillTimer.SkillTimerUpdateHandler OnSkillTimerUpdate;
        SkillTimer PowerBurstTimer;
        SkillTimer SkillCoolDownTimer;
        public override PN PotionName => PN.YellowPaper;
        public override void Update()
        {
            base.Update();
            OnSkillTimerUpdate.Invoke(Time.deltaTime);
        }
        public override void Start()
        {
            //5秒持续时间，0CD。
            PowerBurstTimer = new SkillTimer(5, 0, OnPowerBurstEnd);
            OnSkillTimerUpdate += PowerBurstTimer.OnUpdate;

            //触发类，触发后将IsRunning置True，检查内部 Status 是否为 Ready 以确定是否已完成冷却。
            SkillCoolDownTimer = new SkillTimer(0, 15, null);
            OnSkillTimerUpdate += SkillCoolDownTimer.OnUpdate;
        }
        /// <summary>
        /// 核心换上脑子后，怒气值增加到99%
        /// </summary>
        public override void OnPotionCoreUp()
        {
            Player.playerParameter.MP = Player.playerParameter.MAX_MP - 1;
        }
        /// <summary>
        /// 核心换下脑子后，怒气值设置为0
        /// </summary>
        public override void OnPotionCoreDown()
        {
            Player.playerParameter.MP = 0;
        }
        public override void OnPotionPowerBurst()
        {
            base.OnPotionPowerBurst();
            Player.playerParameter.EXTRA_ATTACK_SPEED += 30;
            PowerBurstTimer.IsRunning = true;
        }
        void OnPowerBurstEnd()
        {
            Player.playerParameter.EXTRA_ATTACK_SPEED -= 30;
        }
    }
}
