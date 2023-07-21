using System.ComponentModel.DataAnnotations;

namespace DaprDotNetJourney.Framework.Abstractions.Application.Models
{
    public class Result<T>
    {
        public Result()
        {
            Messages = new List<string>();
        }
        public virtual ResultType ResultType { get; set; }
        public virtual bool Success { get; set; }
        public virtual List<string> Messages { get; set; }

        [Required(AllowEmptyStrings = true)]
        public virtual T Data { get; set; }
    }
}
