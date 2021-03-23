using System.ComponentModel.DataAnnotations;

namespace Easy.Common.Shared.Entities
{
    public class Entity : IEntity<long>
    {
        [Key]
        public long Id { get; set; }
    }
}
