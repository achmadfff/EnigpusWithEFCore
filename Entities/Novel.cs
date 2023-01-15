using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnigpusEFCore.Entities;

[Table("m_novel", Schema = "dbo")]
public class Novel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(name:"id")]
    public int Id { get; set; }
    
    [Column(name:"code", TypeName = "Nvarchar(25)")]
    public string Code { get; set; }
    
    [Column(name:"title", TypeName = "Nvarchar(50)")]
    public string Title { get; set; }
    
    [Column(name:"publisher", TypeName = "Nvarchar(50)")]
    public string Publisher { get; set; }
    
    [Column(name:"publication_year")]
    public int PublicationYear { get; set; }
    
    [Column(name:"author", TypeName = "Nvarchar(50)")]
    public string Author { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Code)}: {Code}, {nameof(Title)}: " +
               $"{Title}, {nameof(Publisher)}: {Publisher}, {nameof(PublicationYear)}: " +
               $"{PublicationYear}, {nameof(Author)}: {Author}";
    }
}