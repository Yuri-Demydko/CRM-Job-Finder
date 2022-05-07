using System;
using System.ComponentModel.DataAnnotations.Schema;
using CRM.DAL.Models.DatabaseModels.Vacancys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.DAL.Models.DatabaseModels.Tags
{
    public class Tag
    {
        //Для особенностей - возможность повторного использования и более формального вида
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public string TagText { get; set; }
        
        public TagType Type { get; set; }
        
        public Guid VacancyId { get; set; }
        
        public Vacancy Vacancy { get; set; }
    }
    
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> item)
        {
            item.HasOne(i => i.Vacancy)
                .WithMany(i => i.Tags)
                .HasForeignKey(i => i.VacancyId);
            
        }
    }
}