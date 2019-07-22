using System.ComponentModel.DataAnnotations;

namespace DotaApp.Data.Common
{
    public class BaseModel<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
