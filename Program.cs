using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Device
{

    [Required(ErrorMessage = "ID Property Requires Value")]
    public string Id { get; set; }
    [Range(10, 100, ErrorMessage = "Code Value Must Be Within 10-100")]
    public int Code { get; set; }

    [StringLength(100,ErrorMessage = "Max of 100 Charcters are allowed")]//formaterrormessage
    public string Description { get; set; }

}

class Program
{
    static void Main()
    {
        Device deviceObj = new Device();
        List<string> errors;
        ObjectValidator validator = new ObjectValidator();
        bool isValid = validator.Validate(deviceObj, out errors);
        if (!isValid)
        {
            foreach (string item in errors)
            {
                System.Console.WriteLine(item);

            }
        }
    }
}

class ObjectValidator
{
    private List<ValidationResult> validationList = new List<ValidationResult>();
    public bool Validate(Device DeviceObj, out List<string> errors)
    {
        
    var List = DeviceObj as IEnumerable;
        bool IsValid = true;

        if (List == null)
        {
            errors = null;
            return true;
        }

        foreach (var item in List)
        {
            ValidationContext VcObj = new ValidationContext(item);
            var isItemValid = Validator.TryValidateObject(item, VcObj, validationList, true);
            IsValid &= isItemValid;

        }
        errors = new List<string>();
        foreach(var item in validationList)
        {
            errors.Add(item.ToString());
        }

        return IsValid;
    }
}

