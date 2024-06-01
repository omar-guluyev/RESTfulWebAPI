using RESTfulWebAPI.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTfulWebAPI.Entities.ApplicationEntities
{
    public class Student : BaseEntity
    {
        public string FullName { get; set; }

        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}
