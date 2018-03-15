namespace ForumSystem.App.CustomExceptions
{
    using System;

    public class UnexistingPostException : Exception
    {
        public override string Message => "You are trying to access a non-existing post";
    }
}
