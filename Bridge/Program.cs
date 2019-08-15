using System;


namespace Bridge
{
    delegate void ActiveMagicEffect();
    enum WeaponType { OneHandedSword = 1, TwoHandedSword = 2 }
    
    
    abstract class Character
    {
        private Arming _rightHand;
        private Arming _leftHand;
        private bool _isTwoHanded;
        
        public Arming RightHand
        {
            get { return _rightHand; }
            set
            {
                if (value is Shield)
                {
                    Console.WriteLine("Нельзя использовать предмет этой рукой");
                    return;
                }

                _rightHand = value;

                if (value is TwoHandedWeapon)
                {
                    _leftHand = value;
                    _isTwoHanded = true;
                }
                else if (_isTwoHanded)
                {
                    _leftHand = null;
                    _isTwoHanded = false;
                }
            }
        }
        public Arming LeftHand
        {
            get { return _leftHand; }
            set
            {
                _leftHand = value;
                
                if (value is TwoHandedWeapon)
                {
                    _rightHand = value;
                    _isTwoHanded = true;
                }
                else if (_isTwoHanded)
                {
                    _rightHand = null;
                    _isTwoHanded = false;
                }
            }
        }
        
        public abstract void AttackRightHand();

        public abstract void AttackLeftHand();

        public abstract void DefendRightHand();

        public abstract void DefendLeftHand();
    }
    
    interface Arming
    {
        void Attack();
        void Defend();
    }

    interface OneHandedWeapon : Arming
    {
        
    }

    interface TwoHandedWeapon : Arming
    {
        
    }

    interface Shield : Arming
    {
        
    }

    interface CharmedTwoHandedWeapon : TwoHandedWeapon
    {
        void TriggeringActiveMagicEffect();
    }

    class Warrior : Character
    {
        public override void AttackRightHand()
        {
            if(RightHand != null)
                RightHand.Attack();
            else
                Console.WriteLine("Удар правой рукой!");
        }

        public override void AttackLeftHand()
        {
            if (LeftHand != null)
                LeftHand.Attack();
            else
                Console.WriteLine("Удар левой рукой!");
        }

        public override void DefendRightHand()
        {
            if (RightHand != null)
                RightHand.Defend();
            else
                Console.WriteLine("Блок правой рукой!");
        }

        public override void DefendLeftHand()
        {
            if (LeftHand != null)
                LeftHand.Defend();
            else
                Console.WriteLine("Блок левой рукой!");
        }
    }
    
    class OneHandedSword : OneHandedWeapon
    {
        public void Attack()
        {
            Console.WriteLine("Удар одноручным мечом!");
        }

        public void Defend()
        {
            Console.WriteLine("Парирование одноручным мечом!");
        }
    }

    class CommonShield : Shield
    {
        public void Attack()
        {
            Console.WriteLine("Удар обычным щитом!");
        }

        public void Defend()
        {
            Console.WriteLine("Укрыться за обычным щитом!");
        }
    }
    
    class TwoHandedSword : TwoHandedWeapon
    {
        public void Attack()
        {
            Console.WriteLine("Удар двуручным мечом!");
        }
        
        public void Defend()
        {
            Console.WriteLine("Парирование двуручным мечом!");
        }
    }

    class SwordDeadKing : CharmedTwoHandedWeapon
    {
        private AbstractActiveMagicEffect _magicEffect;


        public SwordDeadKing()
        {
            _magicEffect = new FireMagicEffect(WeaponType.TwoHandedSword);
        }
        
        public void Attack()
        {
            TriggeringActiveMagicEffect();
            Console.WriteLine("Удар двуручным мечом!");
        }

        public void Defend()
        {
            Console.WriteLine("Парирование двуручным мечом!"); 
        }

        public void TriggeringActiveMagicEffect()
        {
            _magicEffect.ActivateMagicEffect();
        }
    }

    abstract class AbstractActiveMagicEffect
    {
        public ActiveMagicEffect Activate;
        public string Description { get; protected set; }
        
        public virtual void ActivateMagicEffect()
        {
            Activate();
        }
    }

    class FireMagicEffect : AbstractActiveMagicEffect
    {
        public FireMagicEffect(WeaponType weaponType) 
        {
            Description = "Урон от огня: 12-18(базовый урон)";

            if(weaponType == WeaponType.OneHandedSword)
            {
                Activate = ForOneHandedSword;
            }
            else if(weaponType == WeaponType.TwoHandedSword)
            {
                Activate = ForTwoHandedSword;
            }
        }

        private void ForOneHandedSword()
        {
            Console.WriteLine("Поджог (Атака в цель); Урон от огня 200% в течении 5 секунд");
            //Console.WriteLine("Огненные искры(Урон по области(Три искры); Каждая из которых наносит 33%)");
        }

        private void ForTwoHandedSword()
        {
            Console.WriteLine("Огненная дуга(Атака по области; Урон от огня -50%)");
            //Console.WriteLine("Огненная клин (Атака в цель; Урон от огня +35%)");   
        }
    }
     
    
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            Arming oneHandedSword = new OneHandedSword(); 
            Arming twoHandedSword = new TwoHandedSword(); 
            Arming shield = new CommonShield(); 
            
            warrior.RightHand = oneHandedSword;
            warrior.RightHand = shield;
            warrior.LeftHand = shield;
            warrior.AttackRightHand();
            warrior.DefendLeftHand();
            Console.WriteLine(new string('=', 30));

            warrior.LeftHand = twoHandedSword;
            warrior.AttackRightHand();
            warrior.DefendLeftHand();
            Console.WriteLine(new string('=', 50));

            Arming magicTwoHandedSword = new SwordDeadKing();
            warrior.RightHand = magicTwoHandedSword;
            warrior.AttackRightHand();
            warrior.AttackLeftHand();
            warrior.DefendLeftHand();
            
            Console.ReadKey();
        }
    }
}