using Ardalis.GuardClauses;
using Instrument.Quote.Source.App.Core.ChartAggregate.Mapper;
using Instrument.Quote.Source.App.Core.JoinedChartAggregate.Dto;
using Instrument.Quote.Source.App.Core.JoinedChartAggregate.Interface;
using Instrument.Quote.Source.App.Core.JoinedChartAggregate.Model;
using Instrument.Quote.Source.Shared.Kernal.DataBase.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Instrument.Quote.Source.App.Core.JoinedChartAggregate.Service;
public class JoinedCandleMapper 
{
  private readonly DecimalToStoreIntConverter decMapper;
  private readonly JoinedChart joinChart;

  public JoinedCandleMapper(JoinedChart joinChart)
  {
    Guard.Against.Null(joinChart.StepChart);
    Guard.Against.Null(joinChart.StepChart.Instrument);
    this.joinChart = joinChart;
    decMapper = new DecimalToStoreIntConverter(this.joinChart.StepChart.Instrument);
  }

  public JoinedCandle map(JoinedCandleDto dto)
  {
    return new JoinedCandle(
                        dto.DateTime, dto.TargetDateTime,
                        decMapper.PriceToInt(dto.Open),
                        decMapper.PriceToInt(dto.High), decMapper.PriceToInt(dto.Low),
                        decMapper.PriceToInt(dto.Close),
                        decMapper.VolumeToInt(dto.Volume),
                        dto.IsLast, dto.IsFullCalced,
                        joinChart);
  }

  public JoinedCandleDto map(JoinedCandle entity)
  {
    return new JoinedCandleDto()
    {
      DateTime = entity.StepDateTime,
      TargetDateTime = entity.TargetDateTime,
      Open = decMapper.PriceToDecimal(entity.Open),
      High = decMapper.PriceToDecimal(entity.High),
      Low = decMapper.PriceToDecimal(entity.Low),
      Close = decMapper.PriceToDecimal(entity.Close),
      Volume = decMapper.VolumeToDecimal(entity.Volume),
      IsLast = entity.IsLast,
      IsFullCalced = entity.IsFullCalc
    };
  }
}