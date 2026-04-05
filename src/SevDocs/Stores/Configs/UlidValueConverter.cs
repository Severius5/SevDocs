using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SevDocs.Stores.Configs
{
    internal class UlidValueConverter : ValueConverter<Ulid, string>
    {
        private static readonly ConverterMappingHints DefaultHints = new ConverterMappingHints(26);

        public UlidValueConverter()
            : this(null)
        {
        }

        public UlidValueConverter(ConverterMappingHints mappingHints)
            : base(
                  x => x.ToString(),
                  x => Ulid.Parse(x),
                  DefaultHints.With(mappingHints))
        {
        }
    }
}
