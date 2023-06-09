using Ardalis.Result;
using Instrument.Quote.Source.App.Core.CandleAggregate.Dto;
using Instrument.Quote.Source.App.Core.TimeFrameAggregate.Model;

namespace Instrument.Quote.Source.App.Core.CandleAggregate.Interface;

public interface ICandleSrv
{
  /// <summary>
  /// Get all candles
  /// </summary>
  /// <returns></returns>
  Task<IEnumerable<CandleDto>> GetAllAsync();
  /// <summary>
  /// Get candles by query
  /// </summary>
  /// <param name="instrumentId">Instrument Id</param>
  /// <param name="timeFrameId">TimeFrane Id</param>
  /// <param name="from">from date</param>
  /// <param name="untill">untill date</param>
  /// <exception cref="ArgumentException">One of argument has wrong value</exception>
  /// <returns></returns>
  Task<IEnumerable<CandleDto>> GetAsync(int instrumentId, int timeFrameId, DateTime? from = null, DateTime? untill = null);

  /// <summary>
  /// Get loaded period
  /// </summary>
  /// <param name="instrumentId">Instrument Id</param>
  /// <param name="timeFrameId">TimeFrane Id</param>
  /// <exception cref="ArgumentException">One of argument has wrong value</exception>
  /// <returns></returns>
  Task<Result<PeriodResponseDto>> TryGetExistPeriodAsync(int instrumentId, int timeFrameId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get loaded period for instrument
  /// </summary>
  /// <param name="instrumentId">Instrument Id</param>
  /// <returns></returns>
  Task<Result<IReadOnlyDictionary<string, PeriodResponseDto>>> GetExistPeriodAsync(int instrumentId, CancellationToken cancellationToken = default);
  /// <summary>
  /// Add new candles
  /// </summary>
  /// <param name="instrumentId">Instrument Id</param>
  /// <param name="timeFrameId">TimeFrane Id</param>
  /// <param name="from">from date</param>
  /// <param name="untill">untill date</param>
  /// <param name="candles">new candles</param>
  /// <exception cref="ArgumentException">One of argument has wrong value</exception>
  /// <returns></returns>
  Task<Result<int>> AddAsync(AddCandlesDto addCandlesDto, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get loaded period
  /// </summary>
  /// <param name="instrumentStr">Instrument Id or Str</param>
  /// <param name="timeFrameStr">TimeFrane Id or Str</param>
  /// <returns></returns>
  //Task<Result<PeriodResponseDto>> TryGetExistPeriodAsync(string instrumentStr, string timeframeStr, CancellationToken cancellationToken = default);
}