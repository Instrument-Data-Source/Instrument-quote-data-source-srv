using System.ComponentModel.DataAnnotations;
using Instrument.Quote.Source.App.Core.ChartAggregate.Interface;
using Instrument.Quote.Source.App.Core.ChartAggregate.Validation.Attributes;

namespace Instrument.Quote.Source.App.Core.ChartAggregate.Dto;

public class JoinedCandleDto : CandleDto, IEquatable<JoinedCandleDto>
{
  [Required]
  [UTCKind]
  public DateTime StepDateTime { get; set; }
  public bool IsLast { get; set; }

  public bool Equals(JoinedCandleDto? other)
  {
    return base.Equals(other) &&
           this.StepDateTime == other.StepDateTime &&
           this.IsLast == other.IsLast;
  }
}