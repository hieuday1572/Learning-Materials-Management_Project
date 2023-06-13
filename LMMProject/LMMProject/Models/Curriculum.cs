using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMMProject.Models;

public partial class Curriculum
{
    [Key]
    public int CurriculumId { get; set; }

    public string? CurriculumCode { get; set; }

    public string? NameVn { get; set; }

    public string? NameEn { get; set; }

    public string? Decription { get; set; }

    [ForeignKey("Decision")]
    public string? DecisionNo { get; set; }

    public virtual Decision? Decision { get; set; }

    public int? TotalCredit { get; set; }

    public sbyte? IsActive { get; set; }
 
}
