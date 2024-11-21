namespace assignment1.Models;

using System.ComponentModel.DataAnnotations;
using System.Text;

public class BPMeasureModel
{
        public int Id { get; set; }
    [Display(Name ="Systolic(mm Hg)")] 
    [Required(ErrorMessage = "Systolic value is required.")]
    [Range(20,400,ErrorMessage ="Systolic value is not valid ")]
    [CompareSystolicAndDiastolic(ErrorMessage = "Systolic value must be greater than Diastolic value.")]
    public decimal Systolic { get; set; }
    [Display(Name ="Diastolic(mm Hg)")] 
    [Required(ErrorMessage = "Diastolic value is required.")]
    [Range(10,300,ErrorMessage ="Diastolic values must be a positive integer and lies between 10 and 300 ")]
        public decimal Diastolic { get; set; }
        [Display(Name ="Date Of Measurement")]
        [Required(ErrorMessage = "Measurement date is required.")]
        [DataType(DataType.Date)]
        [PastDateValidate(ErrorMessage = "Measurement date cannot be in the future.")]
        public DateTime MeasurementDate { get; set; }
        
    [Display(Name ="Position")]
    public string positionId { get; set; } 
    
    public Position? position { get; set; } 

   

    public string Category{
        get{
             if(Systolic<120 && Diastolic<80)
                return "Normal";
             
              else if (Systolic < 130 && Diastolic < 80)
                return "Elevated"; 
            else if (Systolic < 140 || Diastolic < 90)
                return "Hypertension Stage 1"; 
            else if (Systolic < 180 || Diastolic < 120)
                return "Hypertension Stage 2"; 
            else
                return "Hypertensive Crisis"; 
        }
    }
    public class PastDateValidate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue && dateValue > DateTime.Now)
        {
            return new ValidationResult("Measurement date cannot be in the future.");
        }
        return ValidationResult.Success;
    }
}

public class CompareSystolicAndDiastolic : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var model = (BPMeasureModel)validationContext.ObjectInstance;
        if (model.Systolic <= model.Diastolic)
        {
            return new ValidationResult("Systolic value must be greater than Diastolic value.");
        }
        return ValidationResult.Success;
    }
}
}


    