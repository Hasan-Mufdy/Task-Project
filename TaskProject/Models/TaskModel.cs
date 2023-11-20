using System.ComponentModel.DataAnnotations;

namespace TaskProject.Models
{
    public class TaskModel
    {
        public int TaskModelId { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string TaskModelName { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string TaskModelDescription { get; set; }
    }
}
