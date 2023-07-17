using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmsnow_NewPotionSystem
{
    /// <summary>
    /// 圣物基类
    /// </summary>
    public abstract class Potion : UnityEngine.MonoBehaviour, IPotion
    {
        protected PlayerAnimControl Player => PlayerAnimControl.instance;
        public abstract PN PotionName { get; }
        public virtual void Update() { }
        public virtual void Start() { }
        public virtual void OnEnemyDealDamage(EnemyControl.Damage damage) { }

        public virtual void OnPlayerDealDamage(EnemyControl.Damage damage) { }

        public virtual void OnPotionAgilityDown() { }

        public virtual void OnPotionAgilityUp() { }

        public virtual void OnPotionConstitueDown() { }

        public virtual void OnPotionConstitueUp() { }

        public virtual void OnPotionCoreDown() { }

        public virtual void OnPotionCoreUp() { }

        public virtual void OnPotionStrengthDown() { }

        public virtual void OnPotionStrengthUp() { }

        public virtual void OnPotionPowerBurst()
        {
            Player.playerParameter.MP = 0;
        }
    }
}
