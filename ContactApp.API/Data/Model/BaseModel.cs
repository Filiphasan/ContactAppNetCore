using ContactApp.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Data.Model
{
    public abstract class BaseModel : IEntity
    {
        //public BaseModel()
        //{
        //    CreatedAt = UpdatedAt = DateTime.UtcNow;
        //}
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
