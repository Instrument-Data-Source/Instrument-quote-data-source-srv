
using System.ComponentModel.DataAnnotations;
using Instrument.Quote.Source.Shared.Kernal.DataBase;
using Instrument.Quote.Source.Shared.Kernal.DataBase.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Instrument.Quote.Source.App.Shared.Validation.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
class ExistIdAttribute<TEntity> : ValidationAttribute where TEntity : EntityBase
{
  public override bool RequiresValidationContext => true;

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var id = (int)value!;
    var entityRep = validationContext.GetService<IReadRepository<TEntity>>();
    if (entityRep == null)
    {
      throw new NullReferenceException($"For validation Id of {typeof(TEntity).Name} validation context must have registered IReadRepository<{typeof(TEntity).Name}> service in ServiceProvider");
    }

    if (!entityRep.ContainId(id))
    {
      return new ValidationResult($"Id must exist in repository", new string[] { validationContext.MemberName! });
    }

    return ValidationResult.Success;
  }
}