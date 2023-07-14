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
        protected PlayerAnimControl _player;
        public Potion(PlayerAnimControl player)
        {
            _player = player;
        }
        public PN PotionName { get; protected set; }
        public virtual void Update()
        {

        }
        public virtual void OnEnemyDealDamage(EnemyControl.Damage damage)
        {

        }

        public virtual void OnPlayerDealDamage(EnemyControl.Damage damage)
        {

        }

        public virtual void OnPotionAgilityDown()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionAgilityUp()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionConstitueDown()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionConstitueUp()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionCoreDown()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionCoreUp()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionStrengthDown()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionStrengthUp()
        {
            throw new NotImplementedException();
        }

        public virtual void OnPotionPowerBurst()
        {
            _player.playerParameter.MP = 0;
        }
    }
}
