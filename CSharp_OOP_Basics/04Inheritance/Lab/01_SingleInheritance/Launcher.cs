public class Launcher
{
    public static void Main()
    {
        var dog = new Dog();
        var cat = new Cat();

        dog.Eat();
        dog.Bark();

        cat.Eat();
        cat.Meow();
    }
}
