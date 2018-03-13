namespace Minedraft.Models
{
    public abstract class BaseModel
    {
        protected BaseModel(string id)
        {
            this.Id = id;
        }

        public string Id { get; }

        public override string ToString()
        {
            return
                this.GetType().Name.Replace(this.GetType().BaseType.Name, "")
                + " "
                + this.GetType().BaseType.Name
                + " - " + this.Id;
        }
    }
}
