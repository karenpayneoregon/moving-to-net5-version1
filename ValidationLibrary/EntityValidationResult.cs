using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ValidationLibrary
{
    public class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; set; }
        public List<string> ErrorMessages => Errors.Select(validationResults => validationResults.ErrorMessage).ToList();
        /// <summary>
        /// Indicates if validation was successful or failed
        /// </summary>
        public bool HasError => Errors.Count > 0;
        public EntityValidationResult(IList<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }
    }
}