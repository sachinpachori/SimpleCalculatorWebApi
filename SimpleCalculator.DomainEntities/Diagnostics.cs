using System;

namespace SimpleCalculator.DomainEntities
{
    public class Diagnostics : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime CreatedOn { set; get; }
        public string Details { set; get; }       
    }
}
