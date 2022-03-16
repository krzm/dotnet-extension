using System.ComponentModel.DataAnnotations;

namespace DotNetExtension;

//https://stackoverflow.com/questions/2712511/data-annotations-for-validation-at-least-one-required-field
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AtLeastOnePropertyAttribute : ValidationAttribute
{
    private string[] PropertyList { get; set; }

    public AtLeastOnePropertyAttribute(params string[] propertyList)
    {
        this.PropertyList = propertyList;
    }

    //See http://stackoverflow.com/a/1365669
    public override object TypeId
    {
        get
        {
            return this;
        }
    }

    public override bool IsValid(object? value)
    {
        foreach (string propertyName in PropertyList)
        {
            var prop = 
                value?.GetType()?.GetProperty(propertyName);
            if (prop != null 
                && prop.GetValue(value, null) != null)
            {
                return true;
            }
        }
        return false;
    }
}