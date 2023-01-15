using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnigpusEFCore.Entities;

[Table("m_magazine", Schema = "dbo")]
public class Magazine
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(name:"id")]
    public int Id { get; set; }
    
    [Column(name:"code", TypeName = "Nvarchar(50)")]
    public string Code { get; set; }
    
    [Column(name:"title", TypeName = "Nvarchar(50)")]
    public string Title { get; set; }
    
    [Column(name:"publishing_period", TypeName = "Nvarchar(50)")]
    public string PublishingPeriod { get; set; }
    
    [Column(name:"publication_year")]
    public int PublicationYear { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Code)}: {Code}, {nameof(Title)}: {Title}, " +
               $"{nameof(PublishingPeriod)}: {PublishingPeriod}, {nameof(PublicationYear)}: {PublicationYear}";
    }
}