using Instrument.Quote.Source.App.Core.CandleAggregate.Dto;
using Instrument.Quote.Source.App.Core.CandleAggregate.Model;
using Instrument.Quote.Source.Shared.Kernal.DataBase.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Instrument.Quote.Source.App.Core.InstrumentAggregate.Repository;

public static class LoadedPeriodRepository
{

  public static async Task<LoadedPeriod> GetForAsync(this IReadRepository<LoadedPeriod> loadedPeriodRep, int instrumentId, int timeFrameId, CancellationToken cancellationToken = default)
  {
    var loadedPer = await loadedPeriodRep.TryGetForAsync(instrumentId, timeFrameId, cancellationToken);
    if (loadedPer == null)
      throw new ArgumentException("No data for InstrumentId and TimeFrameId");
    return loadedPer;
  }

  public static async Task<LoadedPeriod?> TryGetForAsync(this IReadRepository<LoadedPeriod> loadedPeriodRep, int instrumentId, int timeFrameId, CancellationToken cancellationToken = default)
  {
    return await loadedPeriodRep.Table.SingleOrDefaultAsync(e => e.TimeFrameId == timeFrameId && e.InstrumentId == instrumentId, cancellationToken);

  }
}