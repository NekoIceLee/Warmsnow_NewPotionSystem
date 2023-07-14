using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmsnow_NewPotionSystem
{
    public interface IPotion
    {
        public PN PotionName { get; }
        /// <summary>
        /// 装备为核心圣物
        /// </summary>
        public void OnPotionCoreUp();
        /// <summary>
        /// 作为核心圣物被脱下
        /// </summary>
        public void OnPotionCoreDown();
        public void OnPotionAgilityUp();
        public void OnPotionAgilityDown();
        public void OnPotionStrengthUp();
        public void OnPotionStrengthDown();
        public void OnPotionConstitueUp();
        public void OnPotionConstitueDown();
        /// <summary>
        /// 玩家造成伤害
        /// </summary>
        /// <remarks>
        /// 参数为伤害类，可能需要熊将这个类独立出来，然后在圣物系统的调用里面实例化然后传入方法中。
        /// </remarks>
        /// <param name="damage">
        /// 伤害类，待讨论
        /// </param>
        public void OnEnemyDealDamage(EnemyControl.Damage damage);
        /// <summary>
        /// 玩家受到伤害
        /// </summary>
        /// <remarks>
        /// 参数同玩家造成伤害方法，需要讨论
        /// </remarks>
        public void OnPlayerDealDamage(EnemyControl.Damage damage);
        /// <summary>
        /// 圣物怒气爆发
        /// </summary>
        public void OnPotionPowerBurst();

    }
}
