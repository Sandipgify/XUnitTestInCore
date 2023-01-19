namespace DomainModel.Model
{
    public class Client
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreateDate {get;set;}

    }
}
