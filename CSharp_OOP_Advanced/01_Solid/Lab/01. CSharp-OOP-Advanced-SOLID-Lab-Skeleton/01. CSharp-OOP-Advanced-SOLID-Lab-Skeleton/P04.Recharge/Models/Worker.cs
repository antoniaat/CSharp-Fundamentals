namespace P04.Recharge.Models
{
    public abstract class Worker
    {
        protected Worker(string id)
        {
            this.Id = id;
        }

        public virtual void Work(int hours)
        {
            this.WorkingHours += hours;
        }

        public string Id { get; set; }

        public int WorkingHours { get; set; }
    }
}