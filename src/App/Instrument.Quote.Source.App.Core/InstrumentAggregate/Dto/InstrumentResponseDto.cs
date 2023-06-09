namespace Instrument.Quote.Source.App.Core.InstrumentAggregate.Dto;

public class InstrumentResponseDto : IEquatable<InstrumentResponseDto>
{
  
  public InstrumentResponseDto() { }
  


  public InstrumentResponseDto(ent.Instrument entity)
  {
    Id = entity.Id;
    Name = entity.Name;
    Code = entity.Code;
    TypeId = entity.InstrumentTypeId;
    PriceDecimalLen = entity.PriceDecimalLen;
    VolumeDecimalLen = entity.VolumeDecimalLen;
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public string Code { get; set; }
  public int TypeId { get; set; }
  public byte PriceDecimalLen { get; set; }
  public byte VolumeDecimalLen { get; set; }

  public bool Equals(InstrumentResponseDto? other)
  {
    if (other == null) return false;
    if (this == other) return true;
    return Id == other.Id &&
           Name == other.Name &&
           Code == other.Code &&
           TypeId == other.TypeId &&
           PriceDecimalLen == other.PriceDecimalLen &&
           VolumeDecimalLen == other.VolumeDecimalLen;
  }
}