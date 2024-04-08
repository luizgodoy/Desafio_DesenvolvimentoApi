namespace Desafio_Core.Models
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public long CreatedAt { get; set; }
        public long? UpdatedAt { get; set; }
        public long? DeletedAt { get; set; }
        public long CreatedBy { get; set; }        
    }
}