using System.ComponentModel.DataAnnotations;

namespace Core.QuickExtend.Tests.Infrastructure.Enums;

public enum SampleEnum
{
    [Display(Name = "Description of Value1")]
    Value1,

    [Display(Name = "Description of Value2")]
    Value2,

    Value3
}
