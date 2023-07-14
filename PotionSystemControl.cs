using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmsnow_NewPotionSystem
{
    public class PotionSystemControl
    {

        PlayerAnimControl _player;
        private IPotion _core;
        private IPotion _agility;
        private IPotion _strength;
        private IPotion _constitue;
        public IPotion Core
        {
            get => _core; 
            set
            {
                _core?.OnPotionCoreDown();
                _core = value;
                _core?.OnPotionCoreUp();
            }
        }
        public IPotion Agility
        {
            get => _agility; 
            set
            {
                _agility?.OnPotionAgilityDown();
                _agility = value;
                _agility?.OnPotionAgilityUp();
            }
        }
        public IPotion Strength
        {
            get => _strength; 
            set
            {
                _strength?.OnPotionStrengthDown();
                _strength = value;
                _strength?.OnPotionStrengthUp();
            }
        }
        public IPotion Constitue
        {
            get => _constitue; 
            set
            {
                _constitue?.OnPotionConstitueDown();
                _constitue = value;
                _constitue?.OnPotionConstitueUp();
            }
        }

        public void OnPlayerDealDamage(EnemyControl.Damage damage)
        {
            Core?.OnPlayerDealDamage(damage);
            Agility?.OnPlayerDealDamage(damage);
            Strength?.OnPlayerDealDamage(damage);
            Constitue?.OnPlayerDealDamage(damage);
        }

        public void OnEnemyDealDamage(EnemyControl.Damage damage)
        {
            Core?.OnEnemyDealDamage(damage);
            Agility?.OnEnemyDealDamage(damage);
            Strength?.OnEnemyDealDamage(damage);
            Constitue?.OnEnemyDealDamage(damage);
        }
    }
}
