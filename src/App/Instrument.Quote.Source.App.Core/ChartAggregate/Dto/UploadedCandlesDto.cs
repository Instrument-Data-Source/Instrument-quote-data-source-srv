using System.ComponentModel.DataAnnotations;
using Instrument.Quote.Source.App.Core.Validation;
using Instrument.Quote.Source.App.Core.Validation.Wrapper;

namespace Instrument.Quote.Source.App.Core.ChartAggregate.Dto;
public class UploadedCandlesDto
{
  [Required]
  [UTCKind]
  [DataType(DataType.Date)]
  [CompareTo(CompType.LT, nameof(UntillDate))]
  public DateTime FromDate { get; set; }
  [Required]
  [UTCKind]
  [DataType(DataType.Date)]
  [CompareTo(CompType.GT, nameof(FromDate))]
  public DateTime UntillDate { get; set; }

  [EachIsValid<CandleDto>(nameof(CandleDto.DateTime))]
  [Each<Apply<BetweenAttribute>>(nameof(CandleDto.DateTime), new object[] { CompType.GE, nameof(UploadedCandlesDto.FromDate), CompType.LT, nameof(UploadedCandlesDto.UntillDate) })]
  [Map<NoDuplicatesAttribute>(nameof(CandleDto.DateTime))]
  [EachMust<RequiredAttribute>()]
  public IEnumerable<CandleDto> Candles { get; set; }
}