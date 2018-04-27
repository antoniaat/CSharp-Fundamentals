namespace Last_Army.Factory
{
    public class AmmunitionFactory
    {
        public AmmunitionFactory()
        {
        }

        public static IAmmunition CreateAmmunition(string name)
        {
            switch (name)
            {
                case "BulletproofVest":
                    return new BulletproofVest(name);
                case "Grenades":
                    return new Grenades(name);
                case "Helmet":
                    return new Helmet(name);
                case "Knife":
                    return new Knife(name);
                case "NightVision":
                    return new NightVision(name);
                case "Shield":
                    return new Shield(name);
                case "AutomaticMachine":
                    return new AutomaticMachine(name);
                case "Gun":
                    return new Gun(name);
                case "MachineGun":
                    return new MachineGun(name);
            }
            //if none of the above did not match it will be RPG
            return new RPG(name);
        }

        public static Ammunition CreateAmmunitions(string name, int number)
        {
            switch (name)
            {
                case "BulletproofVest":
                    return new BulletproofVest(name, number);
                case "Grenades":
                    return new Grenades(name, number);
                case "Helmet":
                    return new Helmet(name, number);
                case "Knife":
                    return new Knife(name, number);
                case "NightVision":
                    return new NightVision(name, number);
                case "Shield":
                    return new Shield(name, number);
                case "AutomaticMachine":
                    return new AutomaticMachine(name, number);
                case "Gun":
                    return new Gun(name, number);
                case "MachineGun":
                    return new MachineGun(name, number);
            }
            //if none of the above did not match it will be RPG
            return new RPG(name, number);
        }
    }
}